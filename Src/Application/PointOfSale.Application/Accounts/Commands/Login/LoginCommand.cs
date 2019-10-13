using Microsoft.EntityFrameworkCore;
using PointOfSale.Application.Infrastructure;
using PointOfSale.Application.Interfaces;
using PointOfSale.Common.Interfaces;
using PointOfSale.Domain.Entities;
using ReactiveUI;
using Splat;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PointOfSale.Application.Accounts.Commands.Login
{
    public class LoginCommand : BaseCommand, ILoginCommand, IValidatable<LoginCommandValidator>
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

        private LoginCommandValidator validator;

        public LoginCommandValidator Validator
        {
            get { return validator; }
            set { this.RaiseAndSetIfChanged(ref validator, value); }
        }

        private IAuthenticationService authenticationService = Locator.Current.GetService<IAuthenticationService>();


        public LoginCommand()
        {
            Validator = new LoginCommandValidator();
        }

        public async Task<bool> Execute()
        {
            var account = await context.Accounts.SingleOrDefaultAsync(x => x.Username == Username);
            await Task.Delay(5000);
            return account.Password.Verify(Password);
        }

        private void SignIn(Account account)
        {
            authenticationService.SignIn(new ClaimsPrincipal(
                new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, account.ID.ToString()),
                    new Claim(ClaimTypes.Name, account.Username.ToString())
                })
            ));
        }

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = Validator.Validate(this).Errors.FirstOrDefault(error => error.PropertyName == columnName);
                if (firstOrDefault != null)
                    return Validator != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }

        public string Error
        {
            get
            {
                if (Validator != null)
                {
                    var results = Validator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        public bool IsValid
        {
            get
            {
                if(Validator != null)
                {
                    var results = Validator.Validate(this);
                    return results.IsValid;
                }
                return false;
            }
        }

    }

}
