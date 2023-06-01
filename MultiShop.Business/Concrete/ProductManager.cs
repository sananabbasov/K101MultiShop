using System;
using MultiShop.Business.Abstract;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;

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

            foreach (var pl in productCreateDTO.ProductLanguages)
            {
                ProductLanguage productLanguage = new()
                {
                    Name = pl.Name,
                    Description = pl.Description,
                    SeoUrl = "",
                    LangCode = pl.LangCode
                };
                productLanguages.Add(productLanguage);
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

        public Product GetProductById(string id)
        {
            var product = _productDal.Get(x=>x.Id == id);
            return product;
        }

        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }
    }
}

