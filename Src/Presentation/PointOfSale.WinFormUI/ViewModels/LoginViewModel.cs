using PointOfSale.Application.Accounts.Commands.Login;
using ReactiveUI;
using Splat;
using System;
using System.Reactive;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class LoginViewModel : BaseIRoutableViewModel, ILoginCommand
    {

        private string username;

        public string Username
        {
            get { return username; }
            set { this.RaiseAndSetIfChanged(ref username, value); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { this.RaiseAndSetIfChanged(ref password, value); }
        }

        private string usernameErrorMessage;

        public string UsernameErrorMessage
        {
            get { return usernameErrorMessage; }
            set { this.RaiseAndSetIfChanged(ref usernameErrorMessage, value); }
        }

        private string passwordErrorMessage;

        public string PasswordErrorMessage
        {
            get { return passwordErrorMessage; }
            set { this.RaiseAndSetIfChanged(ref passwordErrorMessage, value); }
        }

        private bool isValid;

        public bool IsValid
        {
            get { return isValid; }
            set { this.RaiseAndSetIfChanged(ref isValid, value); }
        }


        public IObservable<bool> CanSubmit => this.WhenAnyValue(
                vm => vm.IsBusy,
                vm => vm.IsValid,
                (B, V) => !B && V
            );

        public ReactiveCommand<Unit, bool> SubmitCommand { get; }

        private readonly LoginCommand loginCommand;

        public LoginViewModel()
        {
            ViewTitle = "Login";

            loginCommand = new LoginCommand();

            SubmitCommand = ReactiveCommand.CreateFromTask(loginCommand.Execute, CanSubmit);
            SubmitCommand.Subscribe(CheckLogin);
            SubmitCommand.IsExecuting.Subscribe(IsExecuting);
            SubmitCommand.ThrownExceptions.Subscribe(ex => this.Log().Error(ex, "Something went Wrong"));

            this.WhenAnyValue(
                vm => vm.Username,
                vm => vm.Password
            ).Subscribe(x =>
            {
                loginCommand.Username = x.Item1;
                loginCommand.Password = x.Item2;
                UsernameErrorMessage = loginCommand[nameof(Username)];
                PasswordErrorMessage = loginCommand[nameof(Password)];
                IsValid = loginCommand.IsValid;
            });
        }

        private void CheckLogin(bool result)
        {
            if (result)
            {
                NavigateAndReset(new DashboardViewModel());
            }
            else
            {
                MessageBox.Show("Account is not Recognized");
            }
        }
    }
}
