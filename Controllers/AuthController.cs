using CaliApp.Application.DTOs;
using CaliApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CaliApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Email and Password are required.");
            }

            try
            {
                var result = await _authService.LoginAsync(request);

                if (result == null)
                {
                    return Unauthorized("Invalid credentials.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework like Serilog or NLog)
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}