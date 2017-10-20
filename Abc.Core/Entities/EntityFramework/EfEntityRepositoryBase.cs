using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Abc.Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Abc.Core.Entities.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntiy = context.Entry(entity); //Nesne Set Edilir.
                addedEntiy.State = EntityState.Added;//Entity Framework nesne gönderilir ve ona eklenecek bir nesne gönderdiğimiz belirtilir.
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntiy = context.Entry(entity);
                addedEntiy.State = EntityState.Modified;
                context.SaveChanges();
            }
         }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntiy = context.Entry(entity); 
                addedEntiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
