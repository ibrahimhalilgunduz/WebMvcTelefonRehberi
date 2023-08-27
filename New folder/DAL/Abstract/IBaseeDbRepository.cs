﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebMvcTelefonRehberi.DAL.Abstract
{
    //Generic Repository Pattern 
    public interface IBaseeDbRepository<TEntity> where TEntity : class, new()
    {
        public void Insert(TEntity entity);
        public void Update(TEntity entity);

        public void Delete(TEntity entity);
        public void Delete(int id);


        public TEntity GetById(int id);

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] include);
    }
}


