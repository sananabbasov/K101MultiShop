using System;
using MultiShop.Entities.DTOs.OrderDTO;

namespace MultiShop.Business.Abstract
{
	public interface IOrderService
	{
		void OrderProduct(OrderItemDTO orderItem);
	}
}

