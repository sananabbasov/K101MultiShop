using MultiShop.Entities.Concrete;

namespace MultiShop.Entities.DTOs.OrderDTO
{
	public class OrderItemDTO
	{
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<string> ProductId { get; set; }
        public Status Status { get; set; }
        public List<decimal> Price { get; set; }
        public List<int> Quantity { get; set; }
    }
}

