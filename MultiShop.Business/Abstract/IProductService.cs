﻿using System;
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
		void UpdateProduct(string id, Product product);
		List<RecentProductDTO> RecentProductList(string langcode);
		List<DiscountProductDTO> DiscountProductList(string langcode);
    }
}

