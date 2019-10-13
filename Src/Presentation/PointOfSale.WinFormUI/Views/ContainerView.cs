using PointOfSale.WinFormUI.ViewModels;
using ReactiveUI;
using Splat;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI.Views
{
    public partial class ContainerView : Form, IViewFor<ContainerViewModel>
    {
        Responsive ResponsiveObj = Locator.Current.GetService<Responsive>();
        GlobalAppSettings appSettings = Locator.Current.GetService<GlobalAppSettings>();

        public ContainerViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ContainerViewModel)value;
        }
        public ContainerView()
        {
            InitializeComponent();

            this.WhenActivated(b => {

                // Bind Router
                b(this.OneWayBind(ViewModel, vm => vm.Router, v => v.routerContent.Router));

                // Bind Properties
                b(this.OneWayBind(ViewModel, vm => vm.Title, v => v.Text));

                // Bind LoadingBar
                b(this.OneWayBind(ViewModel, vm => vm.IsBusy, v => v.loadingBar.Visible));
            });
        }

        private void OnLoad(object sender, EventArgs e)
        {

            MinimumSize = new Size(ResponsiveObj.GetMetrics(MinimumSize.Width, "Width"), ResponsiveObj.GetMetrics(MinimumSize.Height, "Height"));

            this.WindowState = (this.WindowState == FormWindowState.Minimized) ?
                FormWindowState.Normal : appSettings.MainFormState;
            this.Location = (appSettings.MainFormLocation.X == 0 && appSettings.MainFormLocation.Y == 0) ?
                new Point(Screen.GetBounds(this).Width / 2 - Width / 2, Screen.GetBounds(this).Height / 2 - Height / 2 - 30) : appSettings.MainFormLocation;
            this.Size = (appSettings.MainFormSize.Width == 0 && appSettings.MainFormSize.Height == 0) ?
                new Size(ResponsiveObj.GetMetrics(Width, "Width"), ResponsiveObj.GetMetrics(Height, "Height")) : appSettings.MainFormSize;

            ResponsiveObj.SetControls(Controls);
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            appSettings.MainFormState = this.WindowState;
            appSettings.MainFormLocation = (this.WindowState == FormWindowState.Normal) ?
                this.Location : this.RestoreBounds.Location;
            appSettings.MainFormSize = (this.WindowState == FormWindowState.Normal) ?
                this.Size : this.RestoreBounds.Size;
        }
    }
}
