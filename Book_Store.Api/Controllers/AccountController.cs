using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequset requset)
        {
            return Ok(await _authService.Login(requset));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<AuthResponse>> RefreshToken([FromBody] AuthResponse request)
        {
            return Ok(await _authService.RefreshAccessToken(request));
        }

        [HttpPost("LogOut")]
        [ValidateAntiForgeryToken]
        public async Task LogOut()
        {
            await _authService.LogOut();
        }

        [HttpPost("IsEmailInUse/{email}")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var result = await _authService.IsEmailInUse(email);
            if (result != "True") return BadRequest(result);
            return Ok(result);
        }

    }
}
