using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using MultiShop.Core.DataAccess.MongoDb.MongoSettings;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Core.DataAccess.MongoDb.Concrete
{
    public class MongoRepository<TDocument> : IRepositoryBase<TDocument>
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
            throw new NotImplementedException();
        }

        public void Delete(TDocument entity)
        {
            throw new NotImplementedException();
        }

        public TDocument Get(Expression<Func<TDocument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TDocument> GetAll(Expression<Func<TDocument, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(TDocument entity)
        {
            throw new NotImplementedException();
        }
    }
}

