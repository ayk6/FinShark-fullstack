﻿using System.ComponentModel.DataAnnotations;

namespace FinSharkAPI.DTO.Auth
{
	public class LoginDto
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
