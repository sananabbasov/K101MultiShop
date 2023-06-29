using System;
using MultiShop.Entities.DTOs;
using MultiShop.Entities.DTOs.ProductDTO;

namespace MultiShop.Entities.ViewModels
{
	public class ShopVM
	{
		public List<RecentProductDTO> ProductList { get; set; }
		public List<CategoryListDTO> Categories { get; set; }
	}
}

