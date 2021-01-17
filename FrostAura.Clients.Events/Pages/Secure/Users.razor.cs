using FrostAura.Standard.Components.Razor.Abstractions;
using System.Threading.Tasks;

namespace FrostAura.Clients.Events.Pages.Secure
{
    /// <summary>
    /// Users component for authenticated users.
    /// </summary>
    public partial class Users : BaseAuthenticatedComponent<Users>
    {
        /// <summary>
        /// Lifecycle event.
        /// </summary>
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            NavigationService.PageTitleStream.Value = "Users";
        }
    }
}
