using AlIInOne.Dtos.Auth;

namespace AlIInOne.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> InitializeAccount(AuthInitializeDto auth);
        Task<AuthResponseDto> SignIn(AuthSignInDto signInDto);
    }
}
