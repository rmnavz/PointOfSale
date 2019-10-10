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

            this.WhenActivated(d => {

                // Bind Properties
                d(this.Bind(ViewModel, vm => vm.Username, v => v.InputUsername.TextboxText));
                d(this.Bind(ViewModel, vm => vm.Password, v => v.InputPassword.TextboxText));

                d(this.Bind(ViewModel, vm => vm.UsernameErrorMessage, v => v.InputUsername.ErrorMessage));
                d(this.Bind(ViewModel, vm => vm.PasswordErrorMessage, v => v.InputPassword.ErrorMessage));

                // Bind Commands
                d(this.BindCommand(ViewModel, vm => vm.SubmitCommand, v => v.btnLogin));
            });
        }
    }
}
