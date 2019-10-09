using PointOfSale.Application.Accounts.Commands.Login;
using PointOfSale.Persistence;
using ReactiveUI;
using Splat;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { this.RaiseAndSetIfChanged(ref _username, value); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
        }

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
            ApplicationTitle = $"{ApplicationTitle} - Login";

            loginCommand = new LoginCommand(Locator.Current.GetService<DatabaseContext>());

            SubmitCommand = ReactiveCommand.CreateFromTask(DoLoginAsync, CanSubmit);
            SubmitCommand.Subscribe(CheckLogin);
            //SubmitCommand.ThrownExceptions.Subscribe(ExceptionHandler);

            this.WhenAnyValue(
                vm => vm.Username,
                vm => vm.Password
            ).Subscribe(x => {
                loginCommand.Username = x.Item1;
                loginCommand.Password = x.Item2;
            });
        }

        private async Task<bool> DoLoginAsync() => await loginCommand.ExecuteAsync();

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
