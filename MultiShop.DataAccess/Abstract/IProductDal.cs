﻿using System;
using MultiShop.Core.DataAccess;
using MultiShop.Core.DataAccess.MongoDb;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs.ProductDTO;

namespace MultiShop.DataAccess.Abstract
{
	public interface IProductDal : IMongoRepository<Product>
	{
		List<ProductDashboardListDTO> GetProductByLanguage(string langcode);
        List<RecentProductDTO> RecentProducts(string langcode);
        List<RecentProductDTO> FilterProducts(string langcode, decimal? minPrice, decimal? maxPrice, string? categoryId, bool IsDiscounted, int page);
        List<DiscountProductDTO> DiscountProducts(string langcode);
        ProductDetailDTO GetProductById(string langcode, string id);
    }
}

