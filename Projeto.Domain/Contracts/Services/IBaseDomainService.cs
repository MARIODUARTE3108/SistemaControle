using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity> : IDisposable
        where TEntity : class
    {
        void Add(TEntity entity);
        void Modify(TEntity entity);
        void Remove(TEntity entity);

        List<TEntity> GetAll();

        TEntity GetById(Guid id);
    }
}
