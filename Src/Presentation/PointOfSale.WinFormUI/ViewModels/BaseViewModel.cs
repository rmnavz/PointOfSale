using ReactiveUI;
using Splat;
using System;

namespace PointOfSale.WinFormUI.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject
    {
        #region Properties

        private string applicationTitle;

        public string ApplicationTitle
        {
            get { return applicationTitle; }
            set { this.RaiseAndSetIfChanged(ref applicationTitle, value); }
        }

        private string viewTitle;

        public string ViewTitle
        {
            get { return viewTitle; }
            set { this.RaiseAndSetIfChanged(ref viewTitle, value); }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { this.RaiseAndSetIfChanged(ref isBusy, value); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { this.RaiseAndSetIfChanged(ref title, value); }
        }

        #endregion

        public BaseViewModel()
        {
            //Set Properties
            ApplicationTitle = "Point Of Sale";

            IsBusy = false;

            this.WhenAnyValue(
                vm => vm.ApplicationTitle,
                vm => vm.ViewTitle
            ).Subscribe(x => {
                Title = x.Item1 + (x.Item2 != default ? $" - {x.Item2}" : "");
            });
        }

        protected void IsExecuting(bool isExecuting)
        {
            IsBusy = isExecuting;
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
