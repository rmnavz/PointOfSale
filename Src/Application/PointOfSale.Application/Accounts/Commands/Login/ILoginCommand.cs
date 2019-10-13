namespace PointOfSale.Application.Accounts.Commands.Login
{
    public interface ILoginCommand
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
