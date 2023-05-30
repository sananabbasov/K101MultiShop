using System;
namespace MultiShop.Core.DataAccess.MongoDb.MongoSettings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

