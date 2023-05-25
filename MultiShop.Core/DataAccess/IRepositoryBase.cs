using System;
using System.Linq.Expressions;

namespace MultiShop.Core.DataAccess
{
	public interface IRepositoryBase<TEntity> 
	{
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity moentity);
		TEntity Get(Expression<Func<TEntity, bool>> filter);

    }
}

