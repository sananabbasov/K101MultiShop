using System;
using MultiShop.DataAccess.Abstract;

namespace MultiShop.DataAccess.Concrete.MongoDb
{
    public class MProductDal : IProductDal
    {
        public string Add()
        {
            return "Product added to Mongo db";
        }
    }
}

