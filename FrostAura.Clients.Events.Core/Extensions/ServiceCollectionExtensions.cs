using FrostAura.Clients.Events.Core.Interfaces;
using FrostAura.Clients.Events.Core.Managers;
using FrostAura.Standard.Components.Razor.Extensions;
using FrostAura.Standard.Components.Razor.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FrostAura.Clients.Events.Core.Extensions
{
    /// <summary>
    /// Extensions for IServiceCollection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add all required application engine and manager services and config to the DI container.
        /// </summary>
        /// <param name="services">Application services collection.</param>
        /// <param name="config">Configuration for the application.</param>
        /// <returns>Application services collection.</returns>
        public static IServiceCollection AddFrostAuraCore(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddConfig(config)
                .AddServices(config);
        }

        /// <summary>
        /// Add all required application engines configuration to the DI container.
        /// </summary>
        /// <param name="services">Application services collection.</param>
        /// <param name="config">Configuration for the application.</param>
        /// <returns>Application services collection.</returns>
        private static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        /// <summary>
        /// Add all required application engine services to the DI container.
        /// </summary>
        /// <param name="services">Application services collection.</param>
        /// <param name="configuration">Application configuration.</param>
        /// <returns>Application services collection.</returns>
        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient<IDeviceManager, DeviceManager>()
                .AddFrostAuraComponents(c =>
                {
                    var identityServerUrl = configuration.GetValue<string>("Identity:Authority");
                    var scopes = new List<string>();

                    configuration
                        .GetSection("Identity:Scopes")
                        .Bind(scopes);

                    c.AppIdentity = configuration.GetValue<string>("Identity:Audience");
                    c.AppName = configuration.GetValue<string>("Identity:Name");
                    c.AppIconSvgUrl = $"{identityServerUrl}/vectors/icons/fa.client.northwood-crusaders.logo.svg";
                    c.AppSecret = configuration.GetValue<string>("Identity:Secret");
                    c.IdentityServerUrl = identityServerUrl;

                    scopes
                        .ToList()
                        .ForEach(s => c.Scopes.Add(s));

                    // Unauthenticated nav items.
                    c.NavigationItems.Add(new NavLink
                    {
                        IconCssClass = "fa fa-calendar",
                        Title = "Schedule",
                        Path = "/Schedule",
                        MatchType = Microsoft.AspNetCore.Components.Routing.NavLinkMatch.All
                    });
                    c.NavigationItems.Add(new NavLink
                    {
                        IconCssClass = "fa fa-sign-in",
                        Title = "Client Area",
                        Path = $"identity/login?redirectUri={Uri.EscapeUriString("/")}"
                    });

                    // Authenticated nav items.
                    c.NavigationItems.Add(new NavLink
                    {
                        IconCssClass = "fa fa-calendar",
                        Title = "Schedule",
                        Path = "/schedule",
                        RequireAuthentication = true
                    });
                    c.NavigationItems.Add(new NavLink
                    {
                        IconCssClass = "fa fa-users",
                        Title = "Users",
                        Path = "/users",
                        RequireAuthentication = true
                    });
                    c.NavigationItems.Add(new NavLink
                    {
                        IconCssClass = "fa fa-cog",
                        Title = "Settings",
                        Path = "/settings",
                        RequireAuthentication = true
                    });
                    c.NavigationItems.Add(new NavLink
                    {
                        IconCssClass = "fa fa-sign-out",
                        Title = "Sign Out",
                        Path = $"identity/logout?redirectUri={Uri.EscapeUriString("/public")}",
                        RequireAuthentication = true,
                    });
                }, configuration);
        }
    }
}
