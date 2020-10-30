using FrostAura.Clients.Events.Data.Interfaces;
using FrostAura.Clients.Events.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using FrostAura.Libraries.Core.Extensions.Validation;
using Microsoft.Extensions.Logging;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using IdentityModel.Client;
using FrostAura.Clients.Events.Data.Extensions;

namespace FrostAura.Clients.Events.Data.Resources
{
    /// <summary>
    /// Devices resource that communicates with the FrostAura Devices API.
    /// </summary>
    public class FrostAuraDevicesApiResource : IDevicesResource
    {
        /// <summary>
        /// Instance logger.
        /// </summary>
        private readonly ILogger<FrostAuraDevicesApiResource> _logger;
        /// <summary>
        /// Http client factory.
        /// </summary>
        private readonly IHttpClientFactory _clientFactory;
        /// <summary>
        /// FrostAura Devices API GraphQL endpoint.
        /// </summary>
        private readonly string _devicesApiEndpoint;
        /// <summary>
        /// App configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Provide dependencies.
        /// </summary>
        /// <param name="configuration">Application configuration.</param>
        public FrostAuraDevicesApiResource(IConfiguration configuration, IHttpClientFactory httpClientFactory, ILogger<FrostAuraDevicesApiResource> logger)
        {
            _logger = logger
                .ThrowIfNull(nameof(logger));
            _devicesApiEndpoint = configuration
                .ThrowIfNull(nameof(configuration))
                .GetValue<string>("FrostAura:DeviceApiEndpoint")
                .ThrowIfNullOrWhitespace(nameof(_devicesApiEndpoint));
            _clientFactory = httpClientFactory
                .ThrowIfNull(nameof(httpClientFactory));
            _configuration = configuration
                .ThrowIfNull(nameof(configuration));
        }

        /// <summary>
        /// Get all devices that the given token is allowed to view.
        /// </summary>
        /// <param name="sessionToken">Session token.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Devices for the given session token.</returns>
        public async Task<List<Device>> GetDevicesForTokenAsync(string sessionToken, CancellationToken token)
        {
            var attributeCount = (await GetAttributeForTokenAsync(sessionToken.ThrowIfNullOrWhitespace(nameof(sessionToken)), token)).Count;
            var attriFetchMultiplier = 5;
            var attributeCountToFetch = attributeCount > 0 ? attributeCount * attriFetchMultiplier : 5 * attriFetchMultiplier;
            var responseNodes = await QueryPagedGraphQlEndpointAsync<NodeList<Device>>(@"
                query{
                  devices{
                    nodes{
                      id,
                      name,
                      attributes(last: " + attributeCountToFetch.ToString() + @"){
                        nodes{
                          attribute{
                            name
                          }
                          value,
                          timeStamp
                        }
                      }
                    }
                  }
                }
            ", "devices", sessionToken, _devicesApiEndpoint, token);

            return responseNodes
                .Nodes
                .Select(d => d.WithLatestAttributesFirst())
                .Select(d => d.WithDistinctAttributes())
                .OrderBy(d => d.Status)
                .ThenBy(d => d.Name)
                .ToList();
        }

        /// <summary>
        /// Get a device from it's id.
        /// </summary>
        /// <param name="id">Device id.</param>
        /// <param name="sessionToken">Session token.</param>
        /// <param name="token">Cancellation token.</param>
        /// <param name="attributesSetCountToFetch">Number of attribute sets to fetch. E.g. if the desired outcome is to have the latest 2 attributes of the same kind, the value should be 2.</param>
        /// <returns>Device context.</returns>
        public async Task<Device> GetDeviceFromIdAsync(int id, string sessionToken, CancellationToken token, int attributesSetCountToFetch = 1)
        {
            if (id <= 0) throw new ArgumentException(nameof(id));

            var attributeCount = (await GetAttributeForTokenAsync(sessionToken.ThrowIfNullOrWhitespace(sessionToken), token)).Count;
            var attributeCountToFetch = attributeCount > 0 ? attributeCount : 5;
            var response = await QueryPagedGraphQlEndpointAsync<NodeList<Device>>(@"
                query{
                  devices(where: { id: " + id.ToString() + @" }){
                    nodes{
     	                id,
                      name,
                      attributes(last: " + (attributeCountToFetch * attributesSetCountToFetch).ToString() + @"){
                        nodes{
                          attribute{
                            name
                          }
                          value,
                          timeStamp
                        }
                      } 
                    }
                  }
                }
            ", "devices", sessionToken, _devicesApiEndpoint, token);

            return response
                .Nodes
                .First()
                .WithLatestAttributesFirst();
        }

        /// <summary>
        /// Get all attributes that the given token is allowed to view.
        /// </summary>
        /// <param name="sessionToken">Session token.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Attributes for the given session token.</returns>
        public async Task<List<Shared.Models.Venue>> GetAttributeForTokenAsync(string sessionToken, CancellationToken token)
        {
            var response = await QueryPagedGraphQlEndpointAsync<NodeList<Shared.Models.Venue>>(@"
                query{
                  attributes{
                    nodes{
                      id,
                      name
                    }
                  }
                }
            ", "attributes", sessionToken.ThrowIfNullOrWhitespace(sessionToken), _devicesApiEndpoint, token);

            return response.Nodes;
        }

        /// <summary>
        /// Initiate a GraphQL call to a provided endpoint. The query response has to be a node list / paged response.
        /// </summary>
        /// <typeparam name="T">Item type to expect inside of the node list.</typeparam>
        /// <param name="query">GraphQL query.</param>
        /// <param name="responseParentObjectName">Parent obeject name to select as the primary context.</param>
        /// <param name="sessionToken">Auth token.</param>
        /// <param name="endpoint">GraphQL endpoint.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Nodelist of the specified type.</returns>
        private async Task<T> QueryPagedGraphQlEndpointAsync<T>(string query, string responseParentObjectName, string sessionToken, string endpoint, CancellationToken token) where T : new()
        {
            try
            {
                _logger.LogDebug($"Initiating GraphQL query to '{endpoint}'. Query: '{query}'");

                using (var client = _clientFactory.CreateClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {sessionToken}");

                    using (var message = new HttpRequestMessage(HttpMethod.Post, endpoint))
                    {
                        message.Content = new StringContent(JsonConvert.SerializeObject(new
                        {
                            query
                            //operationName = null,
                            //variables = null

                        }), Encoding.UTF8, "application/json");

                        var response = await client.SendAsync(message, token);
                        var responseString = await response.Content.ReadAsStringAsync();
                        var parsedResponse = JObject.Parse(responseString);
                        var extractedResponse = parsedResponse
                            .SelectToken("data");

                        if (!string.IsNullOrWhiteSpace(responseParentObjectName))
                        {
                            extractedResponse = extractedResponse?.SelectToken(responseParentObjectName);
                        }

                        if (extractedResponse == null) return new T();

                        return extractedResponse
                            .ToObject<T>();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to execure GraphQL query to '{endpoint}'. Query: '{query}'. Error: '{ex.Message}'");
            }

            return new T();
        }

        /// <summary>
        /// Add device attributes.
        /// </summary>
        /// <param name="deviceName">Device name.</param>
        /// <param name="attributes">Key value collection of attribute names and values.</param>
        /// <param name="token">Cancellation token.</param>
        public async Task AddDeviceAttributesAsync(string deviceName, IDictionary<string, string> attributes, CancellationToken token)
        {
            var accessToken = await GetClientTokenAsync(token);
            var query = @"
                mutation{
                  upsertAttributeValuesForDevice(request: { 
                    deviceName: " + $"\"{deviceName}\"" + @", 
                    attributes: [
                      " + attributes.Select(a => "{ key: \"" + a.Key + "\", value: \"" + a.Value + "\" }").Aggregate((l, r) => $"{l}, {Environment.NewLine}{r}") + @"
                    ]})
                }    
            ";

            await QueryPagedGraphQlEndpointAsync<object>(query, null, accessToken, _devicesApiEndpoint, token);
        }

        /// <summary>
        /// Get a client token from the identity service.
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Client access token.</returns>
        public async Task<string> GetClientTokenAsync(CancellationToken token)
        {
            // Install identity model package for models.
            var identityAuthority = _configuration
                .GetValue<string>("Identity:Authority");
            var identityAudience = _configuration
                .GetValue<string>("Identity:Audience");
            var identitySecret = _configuration
                .GetValue<string>("Identity:Secret");
            var scopes = new List<string>();

            _configuration
                .GetSection("Identity:Scopes")
                .Bind(scopes);

            var httpClient = _clientFactory.CreateClient();
            var discoveryDocument = await httpClient.GetDiscoveryDocumentAsync(identityAuthority);
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = identityAudience,
                    ClientSecret = identitySecret,
                    Scope = scopes.Aggregate((left, right) => " ")
                }, token);

            return tokenResponse.AccessToken;
        }
    }
}
