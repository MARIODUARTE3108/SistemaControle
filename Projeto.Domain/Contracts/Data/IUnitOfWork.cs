using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        IClienteRepository ClienteRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
 
    }
}
