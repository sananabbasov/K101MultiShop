using System;
namespace MultiShop.Entities.DTOs
{
	public class CategoryCreateDTO
	{
		public List<CategoryLanguageDTO> CategoryLanguages { get; set; }
		public string PhotoUrl { get; set; }
	}
}

