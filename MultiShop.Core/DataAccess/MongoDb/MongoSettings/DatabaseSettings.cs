using System;
namespace MultiShop.Core.DataAccess.MongoDb.MongoSettings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

