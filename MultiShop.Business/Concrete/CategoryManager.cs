using System;
using MultiShop.Business.Abstract;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;

namespace MultiShop.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(CategoryCreateDTO createDTO)
        {
            List<CategoryLanguage> cls = new();

            foreach (var item in createDTO.CategoryLanguages)
            {
                CategoryLanguage cl = new();
                cl.Name = item.Name;
                cl.SeoUrl = "seourlmethod";
                cl.LangCode = item.LangCode;
                cls.Add(cl);
            }

            Category category = new()
            {
                PhotoUrl = createDTO.PhotoUrl,
                CategoryLanguages = cls
            };
            _categoryDal.Add(category);
        }

        public List<CategoryListDTO> GetCategoriesByLanguage(string lang)
        {
            var categories = _categoryDal.GetAll();
   
            var result = categories.Select(x => new CategoryListDTO
            {
                Id = x.Id,
                Name = x.CategoryLanguages.FirstOrDefault(z => z.LangCode == lang).Name,
                LangCode = lang,
                PhotoUrl = x.PhotoUrl,
                SeoUrl = x.CategoryLanguages.FirstOrDefault(z => z.LangCode == lang).SeoUrl,
                ProductCount = 0
            }).ToList();

            return result;
           
        }
    }
}

