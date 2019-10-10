using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Application.Infrastructure;
using PointOfSale.Application.Interfaces;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.Application.Accounts.Commands.Login
{
    public class LoginCommand : BaseCommand, ILoginCommand, IValidatable<LoginCommandValidator>
    {
        [Reactive]
        public string Username { get; set; }

        [Reactive]
        public string Password { get; set; }

        [Reactive]
        public LoginCommandValidator Validator { get; set; }

        public LoginCommand()
        {
            Validator = new LoginCommandValidator();
        }

        public async Task<bool> ExecuteAsync() => (await context.Accounts.SingleOrDefaultAsync(x => 
                x.Username == Username &&
                x.Password == Password
        )).ID != default;

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

    }

    
}
