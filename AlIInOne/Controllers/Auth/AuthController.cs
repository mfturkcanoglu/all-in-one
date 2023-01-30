using AlIInOne.Dtos.Auth;
using AlIInOne.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AlIInOne.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthResponseDto>> InitializeAccount([FromBody] AuthInitializeDto register)
        {
            var result = await _authService.InitializeAccount(register);
            if (result is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(InitializeAccount), result);
        }
    }
}
