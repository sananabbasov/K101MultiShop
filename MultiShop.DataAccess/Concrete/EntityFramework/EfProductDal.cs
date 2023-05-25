using System;
using MultiShop.DataAccess.Abstract;

namespace MultiShop.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public string Add()
        {
            return "Product added to SQL server";
        }
    }
}

