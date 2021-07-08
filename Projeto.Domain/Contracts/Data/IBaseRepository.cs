using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> FindAll();
        List<TEntity> FindAll(int skip, int take);
        List<TEntity> FindAll(Func<TEntity, bool> where);
        TEntity FindById(Guid id);
        TEntity Find(Func<TEntity, bool> where);
    }
}
