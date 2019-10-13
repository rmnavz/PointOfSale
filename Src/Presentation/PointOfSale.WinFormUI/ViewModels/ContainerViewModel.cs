using PointOfSale.Common.Interfaces;
using Splat;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class ContainerViewModel : BaseIScreenViewModel
    {
        private IAuthenticationService authenticationService = Locator.Current.GetService<IAuthenticationService>();

        public ContainerViewModel()
        {
            if(authenticationService.CurrentUser == default)
            {
                NavigateAndReset(new LoginViewModel());
            }
            else
            {
                NavigateAndReset(new DashboardViewModel());
            }
        }
    }
}
