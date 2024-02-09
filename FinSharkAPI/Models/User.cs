using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FinSharkAPI.Models
{
	public class User : IdentityUser
	{
		public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
