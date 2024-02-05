using FinSharkAPI.DTO.Auth;
using FinSharkAPI.Migrations;
using FinSharkAPI.Models;
using FinSharkAPI.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace FinSharkAPI.Services
{
	public class AuthManager : IAuthService
	{
		private readonly UserManager<User> _userManager;
		public AuthManager(UserManager<User> userManager)
		{
			_userManager = userManager;
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
							// Token = _tokenService.CreateToken(user)
						};
				}
			}
			return null;
		}
	}
}
