using System;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;
using MultiShop.Entities.DTOs.ProductDTO;

namespace MultiShop.Business.Abstract
{
	public interface IProductService
	{
		List<Product> GetProducts();
		List<ProductDashboardListDTO> GetDashboardProducts(string langcode);
        Product GetProductById(string id);
		void AddProduct(ProductCreateDTO productCreateDTO);
	}
}

