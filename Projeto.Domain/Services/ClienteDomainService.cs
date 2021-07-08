using Projeto.Domain.Contracts.Data;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class ClienteDomainService
    : BaseDomainService<Cliente>, IClienteDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public ClienteDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.ClienteRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Método para cadastrar um cliente
        /// </summary>
        /// <param name="cliente">Objeto da entidade Cliente</param>
        /// <exception cref="Exceptions.Clientes.EmailDeveSerUnicoException">Erro de email já existente</exception>
        /// <exception cref="Exceptions.Clientes.CpfDeveSerUnicoException">Erro de cpf já existente</exception>
        /// <exception cref="System.Exception">Erro na transação do banco de dados</exception>
        public override void Add(Cliente cliente)
        {
            #region Email deve ser único

            if (unitOfWork.ClienteRepository.Find(c => c.Email.Equals(cliente.Email)) != null)
                throw new EmailDeveSerUnicoException(cliente.Email);

            #endregion


            try
            {
                unitOfWork.BeginTransaction();
                unitOfWork.ClienteRepository.Insert(cliente);

                foreach (var endereco in cliente.Enderecos)
                {
                    endereco.ClienteId = cliente.Id;
                    unitOfWork.EnderecoRepository.Insert(endereco);
                }

                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                unitOfWork.Rollback();
                throw new Exception(e.Message);
            }
        }

        public Cliente Get(string email)
        {
            return unitOfWork.ClienteRepository
                .Find(c => c.Email.Equals(email));


        }
    } 
}
