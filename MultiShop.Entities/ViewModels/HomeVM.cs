using System;
using MultiShop.Entities.DTOs;
using MultiShop.Entities.DTOs.ProductDTO;

namespace MultiShop.Entities.ViewModels
{
	public class HomeVM
	{
		public List<CategoryListDTO> Categories { get; set; }
		public List<RecentProductDTO> RecentProducts { get; set; }
		public List<DiscountProductDTO> DiscountProducts { get; set; }
	}
}

