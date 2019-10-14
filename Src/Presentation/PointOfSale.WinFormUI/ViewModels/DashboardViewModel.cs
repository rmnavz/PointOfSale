using ReactiveUI;
using Splat;
using System;
using System.Reactive;

namespace PointOfSale.WinFormUI.ViewModels
{
    public class DashboardViewModel : BaseIRoutableViewModel
    {
        private string greetings;

        public string Greetings
        {
            get { return greetings; }
            set { this.RaiseAndSetIfChanged(ref greetings, value); }
        }

        public ReactiveCommand<Unit, Unit> LogoutCommand { get; }

        public DashboardViewModel()
        {
            ViewTitle = "Dashboard";

            Greetings = $"Welcome Back {authenticationService.CurrentUser.Identity.Name}";

            LogoutCommand = ReactiveCommand.CreateFromTask(authenticationService.SignOut);
            LogoutCommand.Subscribe(logout);
            LogoutCommand.IsExecuting.Subscribe(IsExecuting);
            LogoutCommand.ThrownExceptions.Subscribe(ex => this.Log().Error(ex, "Something went Wrong"));
        }

        private void logout(Unit unit)
        {
            NavigateAndReset(new LoginViewModel());
        }
    }
}
