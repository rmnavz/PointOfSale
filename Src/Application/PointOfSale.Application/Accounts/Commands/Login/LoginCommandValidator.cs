using FluentValidation;

namespace PointOfSale.Application.Accounts.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }
    }
}
