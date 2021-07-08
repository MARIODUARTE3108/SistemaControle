using Projeto.Domain.Contracts.Data;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class EnderecoDomainService : BaseDomainService<Endereco>, IEnderecoDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public EnderecoDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.EnderecoRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
