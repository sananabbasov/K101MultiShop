﻿using System;
namespace MultiShop.Entities.DTOs.UserDTO
{
	public class LoginDTO
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}

