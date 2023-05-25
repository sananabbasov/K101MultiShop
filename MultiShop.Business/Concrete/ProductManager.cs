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

        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }
    }
}

