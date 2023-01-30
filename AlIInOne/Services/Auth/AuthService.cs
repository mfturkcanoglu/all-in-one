using AlIInOne.Dtos.Auth;
using AlIInOne.Enums;
using AlIInOne.Models;
using Microsoft.AspNetCore.Identity;

namespace AlIInOne.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILecturerService _lecturerService;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<
                IdentityUser> userManager,
                ILecturerService lecturerService,
                IJwtService jwtService
            )
        {
            _userManager = userManager;
            _lecturerService = lecturerService;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto?> InitializeAccount(AuthInitializeDto auth)
        {
            // Create Identity User
            var user = new IdentityUser { UserName = auth.Identity, Email = auth.Email };
            var result = await _userManager.CreateAsync(
                user,
                auth.Password
            );
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description, error.Code);
                }
                Console.WriteLine("Result is not successfull");
                return null;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, auth.Password);
            if (!isPasswordValid)
            {
                Console.WriteLine("Password is not valid");
                return null;
            }

            // TODO: check password

            // Initialize Account
            if (auth.UserType is UserType.LECTURER)
            {
                await _lecturerService.Create(new Lecturer
                {
                    Email = auth.Email,
                    FullName = auth.FullName,
                });
            }
            else if (auth.UserType is UserType.STUDENT)
            {
                // TODO: Implement
            }

            // TODO: Create Token
            AuthResponseDto authResponseDto = _jwtService.CreateToken(user);
            authResponseDto.Email = auth.Email;
            authResponseDto.FullName = auth.FullName;
            authResponseDto.Identity = auth.Identity;

            return authResponseDto;
        }

        public Task<AuthResponseDto> SignIn(AuthSignInDto signInDto)
        {
            throw new NotImplementedException();
        }
    }
}
