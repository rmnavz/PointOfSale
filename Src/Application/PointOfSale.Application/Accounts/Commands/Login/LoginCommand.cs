using Microsoft.EntityFrameworkCore;
using PointOfSale.Application.Infrastructure;
using PointOfSale.Application.Interfaces;
using PointOfSale.Domain.Entities;
using ReactiveUI;
using System;
using System.Linq;
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


        public LoginCommand()
        {
            Validator = new LoginCommandValidator();
        }

        public async Task<bool> Execute()
        {
            Account result = await context.Accounts.SingleOrDefaultAsync(x =>
                x.Username == Username &&
                x.Password.Verify(Password)
            );

            return (result.ID != default);
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
