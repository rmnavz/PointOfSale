using PointOfSale.WinFormUI.ViewModels;
using ReactiveUI;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI.Views
{
    public partial class LoginView : UserControl, IViewFor<LoginViewModel>
    {
        public LoginViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (LoginViewModel)value;
        }

        public LoginView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {

                // Bind Properties
                d(this.Bind(ViewModel, vm => vm.Username, v => v.InputUsername.InputTextBox.Text));
                d(this.Bind(ViewModel, vm => vm.Password, v => v.InputPassword.InputTextBox.Text));

                d(this.Bind(ViewModel, vm => vm.UsernameErrorMessage, v => v.InputUsername.InputErrorMessage.Text));
                d(this.Bind(ViewModel, vm => vm.PasswordErrorMessage, v => v.InputPassword.InputErrorMessage.Text));

                // Bind Commands
                d(this.BindCommand(ViewModel, vm => vm.SubmitCommand, v => v.btnLogin));
            });
        }
    }
}
