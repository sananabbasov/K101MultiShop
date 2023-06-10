using System;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Core.DataAccess.MongoDb
{
	public interface IMongoRepository<TEntity>
		where  TEntity : class, IEntity
	{
		List<TEntity> GetAll();
		TEntity GetById(string id);
		void Add(TEntity entity);
		void Update(string id, TEntity entity);
		void Remove(string id);
	}
}

