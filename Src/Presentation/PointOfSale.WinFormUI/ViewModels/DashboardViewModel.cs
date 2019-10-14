using PointOfSale.Common.Interfaces;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Linq;

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

        private string dateTime;

        public string DateTime
        {
            get { return dateTime; }
            set { this.RaiseAndSetIfChanged(ref dateTime, value); }
        }


        private IDateTime machineDateTime = Locator.Current.GetService<IDateTime>();
        private IAuthenticationService authenticationService = Locator.Current.GetService<IAuthenticationService>();
        public DashboardViewModel()
        {
            ViewTitle = "Dashboard";

            Greetings = $"Welcome Back {authenticationService.CurrentUser.Identity.Name}";

            Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Subscribe(x =>
                {
                    DateTime = machineDateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt");
                });
        }
    }
}
