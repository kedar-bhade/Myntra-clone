using Microsoft.AspNetCore.Mvc;
using MyntraCloneBackend.Models;
using MyntraCloneBackend.Services;
using System.Threading.Tasks;

namespace MyntraCloneBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto dto)
        {
            var ok = await _authService.Register(dto.Username, dto.Password);
            if (!ok) return BadRequest("User already exists");
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto dto)
        {
            var token = _authService.Login(dto.Username, dto.Password);
            if (token == null) return Unauthorized();
            return Ok(new { token });
        }
    }
}
