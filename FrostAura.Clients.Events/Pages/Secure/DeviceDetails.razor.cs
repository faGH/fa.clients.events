using FrostAura.Clients.Events.Data.Interfaces;
using FrostAura.Clients.Events.Shared.Models;
using FrostAura.Standard.Components.Razor.Abstractions;
using FrostAura.Standard.Components.Razor.Models.Geolocation;
using FrostAura.Standard.Components.Razor.Navigation;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FrostAura.Clients.Events.Pages.Secure
{
    /// <summary>
    /// Component for providing a detailed view for a given device.
    /// </summary>
    public partial class DeviceDetails : BaseAuthenticatedComponent<DeviceDetails>
    {
        /// <summary>
        /// Stringified device id from the route.
        /// </summary>
        [Parameter]
        public int? DeviceId { get; set; }
        /// <summary>
        /// FrostAura devices resource.
        /// </summary>
        [Inject]
        public IDevicesResource DevicesResource { get; set; }
        /// <summary>
        /// Device context.
        /// </summary>
        private Device _device { get; set; } = new Device();
        /// <summary>
        /// Loader task for fetching device details.
        /// </summary>
        private Task _loadDeviceDetailsTask;
        /// <summary>
        /// Map component, which will be set when the map becomes ready.
        /// </summary>
        private GoogleMap _mapComponent;
        /// <summary>
        /// Time for the autorefresher to kick in.
        /// </summary>
        private const int AUTO_REFRESH_INTERVAL = 15;

        /// <summary>
        /// Lifecycle event.
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (string.IsNullOrWhiteSpace(Token)) return;

            _loadDeviceDetailsTask = LoadDeviceAsync();
        }

        /// <summary>
        /// Load devices for the UI.
        /// </summary>
        private async Task LoadDeviceAsync()
        {
            _device = await DevicesResource.GetDeviceFromIdAsync(DeviceId.Value, Token, CancellationToken.None, 10);

            StateHasChanged();

            NavigationService.PageTitleStream.Value = $"{_device.Name}";

            await GenerateLocationMarksAsync();
        }

        /// <summary>
        /// Generate location pins for the location attributes for the device.
        /// </summary>
        private async Task GenerateLocationMarksAsync()
        {
            if (_mapComponent == null) return;

            var lats = _device
                .Attributes
                .Nodes
                .Where(a => a.Attribute.Name == "Latitude")?
                .Select(a => a.Value)
                .ToList();
            var lngs = _device
                .Attributes
                .Nodes
                .Where(a => a.Attribute.Name == "Longitude")?
                .Select(a => a.Value)
                .ToList();

            var addMarkerTasks = new List<Task>();

            await _mapComponent.ClearAllMarkersAsync();

            for (int i = 0; i < lats.Count; i++)
            {
                if (i >= lngs.Count) break;

                addMarkerTasks.Add(_mapComponent.AddMarkerAsync(_device.Name, _device.StatusText, double.Parse(lats[i]), double.Parse(lngs[i]), size: 30 / (i + 1)));
            }

            await Task.WhenAll(addMarkerTasks);
        }

        /// <summary>
        /// Remove a given device from
        /// </summary>
        /// <param name="deviceId">Device id to navigate to.</param>
        private Task RemoveDeviceAsync(int deviceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the center point of the map.
        /// </summary>
        /// <returns>Center point of the map.</returns>
        private GeoPoint GetMapCenter()
        {
            if (_device.Id <= 0) return null;

            var lat = _device
                .Attributes
                .Nodes
                .FirstOrDefault(a => a.Attribute.Name == "Latitude")?
                .Value;
            var lng = _device
                .Attributes
                .Nodes
                .FirstOrDefault(a => a.Attribute.Name == "Longitude")?
                .Value;

            return new GeoPoint { Latitude = lat, Longitude = lng };
        }

        /// <summary>
        /// Event handler for when the Google Map is ready.
        /// </summary>
        /// <param name="map">Map that's ready.</param>
        private async Task HandleOnMapReadyAsync(GoogleMap map)
        {
            _mapComponent = map;

            await GenerateLocationMarksAsync();
        }
    }
}
