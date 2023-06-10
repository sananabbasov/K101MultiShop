using System;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Core.DataAccess.MongoDb.MongoSettings;
using MultiShop.Core.Entities.Abstract;
using SharpCompress.Common;

namespace MultiShop.Core.DataAccess.MongoDb.Concrete
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument>
        where TDocument : class, IEntity
    {

        private readonly IMongoCollection<TDocument> _collection;
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public MongoRepository(IDatabaseSettings databaseSettings)
        {
            var database = new MongoClient(databaseSettings.ConnectionString).GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }


        public void Add(TDocument entity)
        {
            _collection.InsertOne(entity);
        }

        public void Update(string id, TDocument entity)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            _collection.ReplaceOne(filter, entity);
        }

        public void Remove(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            _collection.DeleteOne(filter);
        }

        public List<TDocument> GetAll()
        {
            return _collection.Find(FilterDefinition<TDocument>.Empty).ToList();
        }

        public TDocument GetById(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            return _collection.Find(filter).FirstOrDefault();
        }
    }
}

