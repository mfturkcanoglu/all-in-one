using AlIInOne.Dtos.Auth;
using Microsoft.AspNetCore.Identity;

namespace AlIInOne.Services.Auth
{
    public interface IJwtService
    {
        AuthResponseDto CreateToken(IdentityUser user);
    }
}
