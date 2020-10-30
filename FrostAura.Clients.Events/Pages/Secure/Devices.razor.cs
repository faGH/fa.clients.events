using FrostAura.Clients.Events.Data.Interfaces;
using FrostAura.Clients.Events.Shared.Models;
using FrostAura.Standard.Components.Razor.Abstractions;
using FrostAura.Libraries.Core.Extensions.Validation;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FrostAura.Clients.Events.Pages.Secure
{
    /// <summary>
    /// Component for dispaying a collection of authorized devices.
    /// </summary>
    public partial class Devices : BaseAuthenticatedComponent<Devices>
    {
        /// <summary>
        /// FrostAura devices resource.
        /// </summary>
        [Inject]
        public IDevicesResource DevicesResource { get; set; }
        /// <summary>
        /// Internal collection of devices to display.
        /// </summary>
        private Dictionary<string, Device> _devices { get; set; } = new Dictionary<string, Device>();
        /// <summary>
        /// Loading task for devices.
        /// </summary>
        private Task _devicesLoadingTask { get; set; }
        /// <summary>
        /// Time for the autorefresher to kick in.
        /// </summary>
        private const int AUTO_REFRESH_INTERNAL = 15;

        /// <summary>
        /// Lifecycle event.
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            NavigationService.PageTitleStream.Value = "Devices";
            _devicesLoadingTask = LoadDevicesAsync();
        }

        /// <summary>
        /// Load devices for the UI.
        /// </summary>
        private async Task LoadDevicesAsync()
        {
            var devices = await DevicesResource.GetDevicesForTokenAsync(Token.ThrowIfNullOrWhitespace(nameof(Token)), CancellationToken.None);

            _devices.Clear();
            devices.ForEach(d => _devices[d.ToString()] = d);
            StateHasChanged();
        }

        /// <summary>
        /// Navigate to a specific device's view.
        /// </summary>
        /// <param name="deviceId">Device id to navigate to.</param>
        private void NavigateToDevice(int deviceId)
        {
            if (deviceId <= 0) return;

            NavigationManager.NavigateTo($"/device/{deviceId}");
        }

        /// <summary>
        /// Remove a given device from
        /// </summary>
        /// <param name="deviceId">Device id to navigate to.</param>
        private Task RemoveDeviceAsync(int deviceId)
        {
            //if (deviceId <= 0) return;

            return Task.CompletedTask;
            // TODO: Remove the device from the user's owned devices. 
        }
    }
}
