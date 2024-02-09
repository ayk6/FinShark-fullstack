using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinSharkAPI.Models;
using FinSharkAPI.Services.Contracts;
using Microsoft.IdentityModel.Tokens;

namespace FinSharkAPI.Services
{
	public class TokenManager : ITokenService
	{
		private readonly IConfiguration _config;
		private readonly SymmetricSecurityKey _key;
        public TokenManager(IConfiguration config)
        {
			_config = config;
			_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string CreateToken(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
			};

			var cretds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = cretds,
				Issuer = _config["JWT:Issuer"],
				Audience = _config["JWT:Audience"]
			};
			
			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
