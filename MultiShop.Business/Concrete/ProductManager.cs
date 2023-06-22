using System;
using MultiShop.Business.Abstract;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;
using MultiShop.Entities.DTOs;
using MultiShop.Entities.DTOs.CartDTO;
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

        public List<DiscountProductDTO> DiscountProductList(string langcode)
        {
            return _productDal.DiscountProducts(langcode);
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

        public ProductDetailDTO GetProductByLangAndId(string langcode, string id)
        {
            return _productDal.GetProductById(langcode,id);
        }

        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }

        public List<CartProductDTO> GetProductsById(string langcode, List<string> id, List<int> quantity)
        {
            var products = _productDal.GetProductByLanguage(langcode);

            List<CartProductDTO> result = new();


            for (int i = 0; i < id.Count; i++)
            {
                var findProduct = products.FirstOrDefault(x => x.Id == id[i]);
                CartProductDTO cartProductDTO = new()
                {
                    Id  = findProduct.Id,
                    Name =  findProduct.Name,
                    Price = findProduct.Price,
                    Quantity = quantity[i],
                    PhotoUrl = findProduct.PhotoUrl[0]
                };

                result.Add(cartProductDTO);
            }
            return result;
        }

        public List<RecentProductDTO> RecentProductList(string langcode)
        {
            return _productDal.RecentProducts(langcode);
        }

        public void UpdateProduct(string id,Product product)
        {
            for (int i = 0; i < product.ProductLanguages.Count; i++)
            {
                product.ProductLanguages[i].LangCode = i == 0 ? "Az" : i == 1 ? "Ru" : "En";
            }

            _productDal.Update(id,product);
        }
    }
}

