using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;

namespace PointOfSale.Application.Accounts.Commands.Login
{
    public interface ILoginCommand
    {
        [Reactive]
        public string Username { get; set; }

        [Reactive]
        public string Password { get; set; }
    }
}
