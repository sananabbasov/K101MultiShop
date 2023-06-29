using System;
using MultiShop.Core.Entities.Abstract;
using MultiShop.Core.Entities.Concrete;

namespace MultiShop.Entities.Concrete
{
	public class Order : IEntity
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }
		public string ProductId { get; set; }
		public Status Status { get; set; } = Status.Pending;
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public DateTime CreatedDate { get; set; }
	}


	public enum Status
	{
        Pending,
		OnCargo,
		OnWay,
		Delivered
	}
}

