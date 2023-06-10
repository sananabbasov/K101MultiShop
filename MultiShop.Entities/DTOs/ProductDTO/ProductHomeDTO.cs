using System;
namespace MultiShop.Entities.DTOs
{
	public class ProductHomeDTO
	{
		public string Id { get; set; }
		public string PhotoUrl { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
	}
}

