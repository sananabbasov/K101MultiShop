using System;
using MultiShop.Core.Entities.Concrete;
using MultiShop.Entities.DTOs.CartDTO;

namespace MultiShop.Entities.ViewModels
{
	public class CheckOutVM
	{
		public User User { get; set; }
		public List<CartProductDTO> CartProducts { get; set; }
	}
}

