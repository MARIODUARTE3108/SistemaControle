using AutoMapper;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using ProjetoApplication.Contracts;
using ProjetoApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteDomainService clienteDomainService;
        private readonly IMapper mapper;

        public ClienteApplicationService(IClienteDomainService clienteDomainService, IMapper mapper)
        {
            this.clienteDomainService = clienteDomainService;
            this.mapper = mapper;
        }

        public void add(ClienteModel model)
        {
            var cliente = mapper.Map<Cliente>(model);
            clienteDomainService.Add(cliente);
        }

        public void remove(ClienteModel model)
        {
            var cliente = mapper.Map<Cliente>(model);
            clienteDomainService.Remove(cliente);
        }

        public void modify(ClienteModel model)
        {
            var cliente = mapper.Map<Cliente>(model);
            clienteDomainService.Modify(cliente);
        }

        public void GetAll(ClienteModel model)
        {
            var cliente = mapper.Map<Cliente>(model);
            clienteDomainService.GetAll();
        }

        public void Dispose()
        {
            clienteDomainService.Dispose();
        }
    }
}
