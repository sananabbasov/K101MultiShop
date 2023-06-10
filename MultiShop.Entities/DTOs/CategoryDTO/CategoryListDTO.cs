using System;
namespace MultiShop.Entities.DTOs
{
	public class CategoryListDTO
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public string SeoUrl { get; set; }
        public string LangCode { get; set; }
        public string PhotoUrl { get; set; }
        public int ProductCount { get; set; }
    }
}

