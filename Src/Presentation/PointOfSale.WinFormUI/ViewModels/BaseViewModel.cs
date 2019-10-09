using ReactiveUI;
using Splat;

namespace PointOfSale.WinFormUI.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Properties

        private string _applicationTitle;

        public string ApplicationTitle
        {
            get { return _applicationTitle; }
            set { _applicationTitle = value; }
        }

        public IScreen HostScreen => Locator.Current.GetService<IScreen>();
        public string UrlPathSegment { get; protected set; }


        #endregion

        public BaseViewModel()
        {
            //Set Properties
            ApplicationTitle = "Point Of Sale";
        }
    }
}
