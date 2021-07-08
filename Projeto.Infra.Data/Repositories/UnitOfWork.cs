using Microsoft.EntityFrameworkCore.Storage;
using Projeto.Domain.Contracts.Data;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext context;
        private IDbContextTransaction transaction;

        public UnitOfWork(SqlServerContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public IClienteRepository ClienteRepository => new ClienteRepository(context);

        public IEnderecoRepository EnderecoRepository => new EnderecoRepository(context);

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
