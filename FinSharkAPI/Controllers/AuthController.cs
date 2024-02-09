using FinSharkAPI.DTO.Auth;
using FinSharkAPI.Migrations;
using FinSharkAPI.Models;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinSharkAPI.Controllers
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

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var userDto = await _authService.Login(loginDto);
			if (userDto == null) return BadRequest(ModelState);
			return Ok(userDto);

		}

        [HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
	
			var userDto = await _authService.Register(registerDto);
			if (userDto == null) return BadRequest(ModelState);
			return Ok(userDto);
		}
	}
}
