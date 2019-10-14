namespace PointOfSale.WinFormUI.ViewModels
{
    public class ContainerViewModel : BaseIScreenViewModel
    {

        public ContainerViewModel()
        {
            if (authenticationService.CurrentUser == default)
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
