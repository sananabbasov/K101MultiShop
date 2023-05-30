using System;
using MultiShop.Entities.Concrete;

namespace MultiShop.Business.Abstract
{
	public interface IProductService
	{
		List<Product> GetProducts();
		Product GetProductById(int id);
		void AddProduct(Product product);
	}
}

