using System;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class ContainerViewModel : BaseIScreenViewModel
    {

        public ContainerViewModel()
        {
            Router
                .NavigateAndReset
                .Execute(new LoginViewModel())
                .Subscribe();
        }
    }
}
