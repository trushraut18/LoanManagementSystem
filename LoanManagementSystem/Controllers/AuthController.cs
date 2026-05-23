using LoanManagementSystem.Application.DTOs;
using LoanManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var response = await _authService.RegisterAsync(request);
            return Ok(response);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto register)
        {
            var response = await _authService.LoginAsync(register);
            if(response == null)
            {
                return Unauthorized("Invalid Credentials");
            }
            return Ok(response);
        }

    }


}
