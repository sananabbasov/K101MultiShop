using System;
using MultiShop.Business.Abstract;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;
using MultiShop.Entities.DTOs.ProductDTO;

namespace MultiShop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public void AddProduct(ProductCreateDTO productCreateDTO)
        {
            List<ProductLanguage> productLanguages = new();
            int count = 0;
            foreach (var pl in productCreateDTO.ProductLanguages)
            {
                ProductLanguage productLanguage = new()
                {
                    Name = pl.Name,
                    Description = pl.Description,
                    SeoUrl = "",
                    LangCode = count == 0 ? "Az" : count == 1 ? "Ru" : "En"
                };
                productLanguages.Add(productLanguage);
                count++;
            }

            Product product = new()
            {
                ProductLanguages = productLanguages,
                Price = productCreateDTO.Price,
                Discount = productCreateDTO.Discount,
                DiscountEndDate = productCreateDTO.DiscountEndDate,
                Categories = productCreateDTO.Categories,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsActive = false,
                IsDeleted = false,
                PhotoUrl = productCreateDTO.PhotoUrl
            };
            _productDal.Add(product);
        }

        public List<ProductDashboardListDTO> GetDashboardProducts(string langcode)
        {
            return _productDal.GetProductByLanguage(langcode);
        }

        public Product GetProductById(string id)
        {
            var product = _productDal.GetById(id);
            return product;
        }

        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }
    }
}

