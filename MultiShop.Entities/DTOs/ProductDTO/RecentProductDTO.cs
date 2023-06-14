using System;
namespace MultiShop.Entities.DTOs.ProductDTO
{
	public class RecentProductDTO
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrl { get; set; }
        public List<string> Categories { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}

