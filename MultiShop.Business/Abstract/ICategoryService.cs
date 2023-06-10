using System;
using MultiShop.Entities.DTOs;

namespace MultiShop.Business.Abstract
{
	public interface ICategoryService
	{
		void AddCategory(CategoryCreateDTO createDTO);
		List<CategoryListDTO> GetCategoriesByLanguage(string lang);
	}
}

