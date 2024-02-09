using FinSharkAPI.DTO.Auth;
using FinSharkAPI.Models;

namespace FinSharkAPI.Services.Contracts
{
	public interface IAuthService
	{
		Task<UserDto?> Register(RegisterDto registerDto);
		Task<UserDto?> Login(LoginDto loginDto);
	}
}
