using ReactiveUI;

namespace PointOfSale.WinFormUI.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject
    {
        #region Properties

        private string _applicationTitle;

        public string ApplicationTitle
        {
            get { return _applicationTitle; }
            set { _applicationTitle = value; }
        }


        #endregion

        public BaseViewModel()
        {
            //Set Properties
            ApplicationTitle = "Point Of Sale";
        }
    }
}
