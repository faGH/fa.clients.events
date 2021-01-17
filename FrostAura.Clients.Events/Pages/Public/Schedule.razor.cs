using FrostAura.Standard.Components.Razor.Abstractions;
using System.Threading.Tasks;

namespace FrostAura.Clients.Events.Pages.Public
{
    /// <summary>
    /// Public schedule component.
    /// </summary>
    public partial class Schedule : BaseComponent<Schedule>
    {
        /// <summary>
        /// Lifecycle event.
        /// </summary>
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            NavigationService.PageTitleStream.Value = "Schedule";
        }
    }
}
