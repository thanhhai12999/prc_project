﻿using PRC_Project.Data.Helper;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PRC_Project.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<PaginatedList<TEntity>> Get(int pageIndex = 0 , int pageSize= 0 , Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
                                         string includeProperties = "");
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         string includeProperties = "");

        Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        Task<TEntity> GetById(object id);
        IQueryable<TEntity> GetByObject(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Delete(object id);
        void Update(TEntity entityToUpdate);
    }
}
