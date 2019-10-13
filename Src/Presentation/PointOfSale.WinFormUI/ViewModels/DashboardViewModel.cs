using PointOfSale.Common.Interfaces;
using ReactiveUI;
using Splat;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class DashboardViewModel : BaseIRoutableViewModel
    {
        private string greetings;

        public string Greetings
        {
            get { return greetings; }
            set { this.RaiseAndSetIfChanged(ref greetings, value); }
        }


        private IAuthenticationService authenticationService = Locator.Current.GetService<IAuthenticationService>();
        public DashboardViewModel()
        {
            ViewTitle = "Dashboard";

            Greetings = $"Welcome Back {authenticationService.CurrentUser.Identity.Name}";

        }
    }
}
