using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebMvcTelefonRehberi.DAL.Abstract;
using WebMvcTelefonRehberi.Domain;

namespace WebMvcTelefonRehberi.DAL.EfCore
{
    public class BaseeDbRepository<TEntity> : IBaseeDbRepository<TEntity>
        where TEntity : class, new()
    {
        BaseeDbContext dbContext;
        private DbSet<TEntity> table = null;
        public BaseeDbRepository()
        {
            dbContext = new BaseeDbContext();
        }

        public TEntity GetById(int id)
        {

            return dbContext.Set<TEntity>().Find(id);
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return dbContext.Set<TEntity>().ToList();
            }
            else
            {
                return dbContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {



            //dbContext.Entry(entity).State = EntityState.Modified;
            //dbContext.Update<TEntity>(entity);
            dbContext.Entry<TEntity>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {

            var query = dbContext.Set<TEntity>().Where(filter);
            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));




        }
    }
}
