using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;

namespace PointOfSale.WinFormUI.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject
    {
        #region Properties

        [Reactive]
        public string ApplicationTitle { get; set; }

        [Reactive]
        public string ViewTitle { get; set; }

        [Reactive]
        public bool IsBusy { get; set; }

        [Reactive]
        public string Title { get; set; }

        #endregion

        public BaseViewModel()
        {
            //Set Properties
            ApplicationTitle = "Point Of Sale";

            this.WhenAnyValue(
                vm => vm.ApplicationTitle,
                vm => vm.ViewTitle
            ).Subscribe(x => {
                Title = x.Item1 + (x.Item2 != default ? $" - {x.Item2}" : "");
            });
        }
    }

    public abstract class BaseIRoutableViewModel : BaseViewModel, IRoutableViewModel {
        public IScreen HostScreen => Locator.Current.GetService<IScreen>();
        public string UrlPathSegment { get; protected set; }
    }
    public abstract class BaseIScreenViewModel : BaseViewModel, IScreen {
        public RoutingState Router { get; }

        public BaseIScreenViewModel()
        {
            // Create router for IScreen
            Router = new RoutingState();
        }
    }
}
