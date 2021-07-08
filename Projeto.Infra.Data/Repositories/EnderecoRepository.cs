using Projeto.Domain.Contracts.Data;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly SqlServerContext context;

        public EnderecoRepository(SqlServerContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
