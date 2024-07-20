using Microsoft.AspNetCore.Identity;

namespace INDIA.Repository.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
