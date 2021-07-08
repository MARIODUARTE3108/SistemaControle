using Projeto.Domain.Contracts.Data;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public abstract class BaseDomainService<TEntity>
           : IBaseDomainService<TEntity>
           where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;

        protected BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Add(TEntity entity)
        {
            repository.Insert(entity);
        }

        public virtual void Modify(TEntity entity)
        {
            repository.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            repository.Delete(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return repository.FindAll();
        }


        public virtual TEntity GetById(Guid id)
        {
            return repository.FindById(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
