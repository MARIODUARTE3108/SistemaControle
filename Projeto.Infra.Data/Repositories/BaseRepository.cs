using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Data;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly SqlServerContext context;

        //construtor para injeção de dependencia
        public BaseRepository(SqlServerContext context)
        {
            this.context = context;
        }

        public virtual void Insert(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual List<TEntity> FindAll()
        {
            return context.Set<TEntity>()
                .ToList();
        }

        public List<TEntity> FindAll(int skip, int take)
        {
            return context.Set<TEntity>()
                    .Skip(skip)
                    .Take(take)
                    .ToList();
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> where)
        {
            return context.Set<TEntity>()
                .Where(where)
                .ToList();
        }

        public List<TEntity> FindAll(Func<TEntity, bool> where, int skip, int take)
        {
            return context.Set<TEntity>()
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public virtual TEntity FindById(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual TEntity Find(Func<TEntity, bool> where)
        {
            return context.Set<TEntity>().FirstOrDefault(where);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
