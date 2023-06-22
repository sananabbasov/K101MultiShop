using System;
using System.ComponentModel.DataAnnotations;

namespace MultiShop.Entities.DTOs.UserDTO
{
	public class RegisterDTO
	{
		[Required(ErrorMessage= "Bütün xanaları doldurun")]
        [StringLength(16,MinimumLength=3,ErrorMessage="Ad minumum 3 maksimum 16 simvol ola bilər.")]
		public string FirstName { get; set; }
        [Required(ErrorMessage = "Bütün xanaları doldurun")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Soyad minumum 3 maksimum 16 simvol ola bilər.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Bütün xanaları doldurun")]
        [EmailAddress]
		public string Email { get; set; }
        [Required(ErrorMessage = "Bütün xanaları doldurun")]
        [DataType(DataType.Password)]
		public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bütün xanaları doldurun")]
        [Compare("Password", ErrorMessage="Şifrələr üst-üstə düşmür.")]
		public string PasswordRepeat { get; set; }
	}
}

