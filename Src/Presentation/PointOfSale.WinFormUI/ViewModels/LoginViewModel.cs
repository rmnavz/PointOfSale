using PointOfSale.Application.Accounts.Commands.Login;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class LoginViewModel : BaseIRoutableViewModel, ILoginCommand
    {
        [Reactive]
        public string Username { get; set; }
        
        [Reactive]
        public string Password { get; set; }

        [Reactive]
        public string UsernameErrorMessage { get; set; }

        [Reactive]
        public string PasswordErrorMessage { get; set; }

        public IObservable<bool> CanSubmit => this.WhenAnyValue(
                vm => vm.Username,
                vm => vm.Password,
                vm => vm.IsBusy,
                (E, P, B) =>
                    !string.IsNullOrWhiteSpace(E) &&
                    !string.IsNullOrWhiteSpace(P) &&
                    !B
            );

        public ReactiveCommand<Unit, bool> SubmitCommand { get; }

        private readonly LoginCommand loginCommand;

        public LoginViewModel()
        {
            ViewTitle = "Login";

            loginCommand = new LoginCommand();

            SubmitCommand = ReactiveCommand.CreateFromTask(DoLoginAsync, CanSubmit);
            SubmitCommand.Subscribe(CheckLogin);
            //SubmitCommand.ThrownExceptions.Subscribe(ExceptionHandler);

            this.WhenAnyValue(
                vm => vm.Username,
                vm => vm.Password
            ).Subscribe(x => {
                loginCommand.Username = x.Item1;
                loginCommand.Password = x.Item2;
                UsernameErrorMessage = loginCommand[nameof(Username)];
                PasswordErrorMessage = loginCommand[nameof(Password)];
            });
        }

        private async Task<bool> DoLoginAsync()
        {
            return await loginCommand.ExecuteAsync();
        }

        private void CheckLogin(bool result)
        {
            if (result)
            {
                
            }
            else
            {
                IsBusy = false;
            }
        }
    }
}
