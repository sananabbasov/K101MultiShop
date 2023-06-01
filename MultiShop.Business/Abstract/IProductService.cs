using System;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;

namespace MultiShop.Business.Abstract
{
	public interface IProductService
	{
		List<Product> GetProducts();
		Product GetProductById(string id);
		void AddProduct(ProductCreateDTO productCreateDTO);
	}
}

