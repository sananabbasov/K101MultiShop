﻿using System;
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
            using var context = new TContext();
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var removeEntity = context.Remove(entity);
            removeEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            return filter != null
                ? context.Set<TEntity>().Where(filter).ToList()
                : context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var updateEntity = context.Update(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

