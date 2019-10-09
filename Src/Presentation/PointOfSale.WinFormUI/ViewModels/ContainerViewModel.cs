using ReactiveUI;
using System;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class ContainerViewModel : ReactiveObject, IScreen
    {
        private string _applicationTitle;

        public string ApplicationTitle
        {
            get { return _applicationTitle; }
            set { _applicationTitle = value; }
        }

        public RoutingState Router { get; }

        public ContainerViewModel()
        {
            // Create router for IScreen
            Router = new RoutingState();

            //Set Properties
            ApplicationTitle = "Point Of Sale";

            Router
                .NavigateAndReset
                .Execute(new LoginViewModel())
                .Subscribe();
        }
    }
}
