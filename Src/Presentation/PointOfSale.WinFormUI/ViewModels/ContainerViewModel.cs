using ReactiveUI;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class ContainerViewModel : BaseViewModel, IScreen
    {
        public RoutingState Router { get; }

        public ContainerViewModel()
        {
            // Create router for IScreen
            Router = new RoutingState();
        }
    }
}
