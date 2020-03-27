﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplication.Contracts;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext RepositoryContext { get; set; }

        protected RepositoryBase(AppDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public virtual IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
