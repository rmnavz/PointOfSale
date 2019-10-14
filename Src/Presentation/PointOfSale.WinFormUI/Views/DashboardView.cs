using PointOfSale.WinFormUI.ViewModels;
using ReactiveUI;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI.Views
{
    public partial class DashboardView : UserControl, IViewFor<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DashboardViewModel)value;
        }

        public DashboardView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {

                // Bind Properties
                d(this.OneWayBind(ViewModel, vm => vm.Greetings, v => v.lblGreetings.Text));
                d(this.OneWayBind(ViewModel, vm => vm.DateTime, v => v.lblClock.Text));
            });
        }
    }
}
