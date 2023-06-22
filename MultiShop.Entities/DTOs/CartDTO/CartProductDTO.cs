using System;
namespace MultiShop.Entities.DTOs.CartDTO
{
	public class CartProductDTO
	{
        public CartProductDTO()
        {
            TotalPrice = Quantity * Price;
        }

        public string Id { get; set; }
		public int Quantity { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string PhotoUrl { get; set; }
		public decimal TotalPrice;

	}
}

