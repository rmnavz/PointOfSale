using PointOfSale.Common.Interfaces;
using Splat;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PointOfSale.Infrastructure
{
    public class AuthenticationService : IAuthenticationService
    {
        public ClaimsPrincipal CurrentUser()
        {
            return Locator.Current.GetService<ClaimsPrincipal>();
        }

        public Task SignIn(ClaimsPrincipal claimsPrincipal)
        {
            Locator.CurrentMutable.RegisterConstant(claimsPrincipal, typeof(ClaimsPrincipal));

            return Task.CompletedTask;
        }

        public Task SignOut()
        {
            Locator.CurrentMutable.UnregisterCurrent<ClaimsPrincipal>();

            return Task.CompletedTask;
        }
    }
}
