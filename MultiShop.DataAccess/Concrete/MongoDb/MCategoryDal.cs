using System;
using MongoDB.Driver;
using MultiShop.Core.DataAccess.MongoDb.Concrete;
using MultiShop.Core.DataAccess.MongoDb.MongoSettings;
using MultiShop.DataAccess.Abstract;
using MultiShop.Entities.Concrete;

namespace MultiShop.DataAccess.Concrete.MongoDb
{
    public class MCategoryDal : MongoRepository<Category>, ICategoryDal
    {

        private readonly IMongoCollection<Category> _collection;
        public MCategoryDal(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            var database = new MongoClient(databaseSettings.ConnectionString).GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Category>("categories");
        }

        public List<string> GetCategoriesByLanguage(string langcode, List<string> categoryId)
        {
            var categories = _collection.Find(FilterDefinition<Category>.Empty).ToList();

            var result = categories.Where(x=> categoryId.Contains(x.Id)).Select(x => new
            {
                x.CategoryLanguages.FirstOrDefault(x=>x.LangCode == langcode).Name
            }).Select(x => x.ToString()).ToList();
            return result;
        }
    }
}

