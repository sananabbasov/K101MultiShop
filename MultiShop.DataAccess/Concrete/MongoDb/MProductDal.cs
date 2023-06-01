using System;
using MultiShop.Core.DataAccess.MongoDb.Concrete;
using MultiShop.Core.DataAccess.MongoDb.MongoSettings;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;

namespace MultiShop.DataAccess.Concrete.MongoDb
{
    public class MProductDal : MongoRepository<Product>, IProductDal
    {
        public MProductDal(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }
    }
}

