using FrostAura.Clients.Events.Shared.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Venue = FrostAura.Clients.Events.Shared.Models.Venue;

namespace FrostAura.Clients.Events.Data.Interfaces
{
    /// <summary>
    /// Interface for a devices resource provider.
    /// </summary>
    public interface IDevicesResource
    {
        /// <summary>
        /// Get all devices that the given token is allowed to view.
        /// </summary>
        /// <param name="sessionToken">Session token.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Devices for the given session token.</returns>
        Task<List<Device>> GetDevicesForTokenAsync(string sessionToken, CancellationToken token);
        /// <summary>
        /// Get all attributes that the given token is allowed to view.
        /// </summary>
        /// <param name="sessionToken">Session token.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Attributes for the given session token.</returns>
        Task<List<Venue>> GetAttributeForTokenAsync(string sessionToken, CancellationToken token);
        /// <summary>
        /// Get a device from it's id.
        /// </summary>
        /// <param name="id">Device id.</param>
        /// <param name="sessionToken">Session token.</param>
        /// <param name="token">Cancellation token.</param>
        /// <param name="attributesSetCountToFetch">Number of attribute sets to fetch. E.g. if the desired outcome is to have the latest 2 attributes of the same kind, the value should be 2.</param>
        /// <returns>Device context.</returns>
        Task<Device> GetDeviceFromIdAsync(int id, string sessionToken, CancellationToken token, int attributesSetCountToFetch = 1);
        /// <summary>
        /// Add device attributes.
        /// </summary>
        /// <param name="deviceName">Device name.</param>
        /// <param name="attributes">Key value collection of attribute names and values.</param>
        /// <param name="token">Cancellation token.</param>
        Task AddDeviceAttributesAsync(string deviceName, IDictionary<string, string> attributes, CancellationToken token);
    }
}
