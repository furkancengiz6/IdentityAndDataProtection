using IdentityAndDataProtection.Enities;

namespace IdentityAndDataProtection.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}
