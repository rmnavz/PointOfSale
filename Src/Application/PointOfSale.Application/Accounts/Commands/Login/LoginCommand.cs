using Microsoft.EntityFrameworkCore;
using PointOfSale.Persistence;
using System;
using System.Threading.Tasks;

namespace PointOfSale.Application.Accounts.Commands.Login
{
    public class LoginCommand
    {
        private DatabaseContext _context { get; set; }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public LoginCommand(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> ExecuteAsync() => (await _context.Accounts.SingleOrDefaultAsync(x => 
                x.Username == Username &&
                x.Password == Password
        )).ID != Guid.Empty;

    }
}
