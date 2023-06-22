using System;
namespace MultiShop.Entities.DTOs.ProductDTO
{
	public class ProductDetailDTO
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public List<string> PhotoUrl { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
	}
}

