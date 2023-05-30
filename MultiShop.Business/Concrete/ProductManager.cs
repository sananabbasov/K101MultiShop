using System;
using MultiShop.Business.Abstract;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;

namespace MultiShop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddProduct(Product product)
        {
            _productDal.Add(product);
        }

        public Product GetProductById(int id)
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

