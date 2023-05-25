using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
        
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

