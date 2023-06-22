using System;
using Microsoft.AspNetCore.Identity;

namespace MultiShop.Core.Entities.Concrete
{
	public class User : IdentityUser
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserToken { get; set; }
		public DateTime BirthDay { get; set; }
	}
}

