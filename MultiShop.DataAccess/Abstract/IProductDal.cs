using System;
using MultiShop.Core.DataAccess;
using MultiShop.Core.DataAccess.MongoDb;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs.ProductDTO;

namespace MultiShop.DataAccess.Abstract
{
	public interface IProductDal : IMongoRepository<Product>
	{
		List<ProductDashboardListDTO> GetProductByLanguage(string langcode);
	}
}

