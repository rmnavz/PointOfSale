using System.Security.Claims;
using System.Threading.Tasks;

namespace PointOfSale.Common.Interfaces
{
    public interface IAuthenticationService
    {
        Task SignIn(ClaimsPrincipal claimsPrincipal);

        Task SignOut();

        ClaimsPrincipal CurrentUser();
    }
}
