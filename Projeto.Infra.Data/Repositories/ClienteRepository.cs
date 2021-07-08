using Projeto.Domain.Contracts.Data;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly SqlServerContext context;

        public ClienteRepository(SqlServerContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
