using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Entities.Concrete;

namespace MultiShop.Entities.DTOs
{
	public class ProductCreateDTO
    {
        public List<ProductLanguageDTO> ProductLanguages { get; set; }
        public List<string> PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public List<string> Categories { get; set; }
    }
}

