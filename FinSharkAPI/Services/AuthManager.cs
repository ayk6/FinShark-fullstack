using FinSharkAPI.DTO.Auth;
using FinSharkAPI.Models;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinSharkAPI.Services
{
	public class AuthManager : IAuthService
	{
		private readonly UserManager<User> _userManager;
		private readonly ITokenService _tokenService;
		private readonly SignInManager<User> _signInManager;
		public AuthManager(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_tokenService = tokenService;
			_signInManager = signInManager;
		}

		public async Task<UserDto?> Login(LoginDto loginDto)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

			if (user == null) throw new Exception("invalid user");

			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

			if (!result.Succeeded) throw new Exception("invalid user or password");

			return new UserDto
			{
				UserName = loginDto.UserName,
				Email = user.Email,
				Token = _tokenService.CreateToken(user)
			};
		}

		public async Task<UserDto?> Register(RegisterDto registerDto)
		{
			var user = new User
			{
				UserName = registerDto.UserName,
				Email = registerDto.Email
			};

			var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

			if (createdUser.Succeeded)
			{
				var roleResult = await _userManager.AddToRoleAsync(user, "User");
				if (roleResult.Succeeded)
				{
					return
						new UserDto
						{
							UserName = user.UserName,
							Email = user.Email,
							Token = _tokenService.CreateToken(user)
						};
				}
			}
			return null;
		}
	}
}
