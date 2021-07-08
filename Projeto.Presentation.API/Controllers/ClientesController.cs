using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Entities;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Repositories;
using ProjetoApplication.Contracts;
using ProjetoApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteApplicationService clienteApplicationService;

        //construtor para injeção de dependência..
        public ClientesController(IClienteApplicationService clienteApplicationService)
        {
            this.clienteApplicationService = clienteApplicationService;
        }

        [HttpPost]
        public IActionResult Post(ClienteModel model)
        {
            try
            {
                clienteApplicationService.add(model);

                return Ok(
                    new
                    {
                        Mensagem = "Cliente cadastrado com sucesso.",
                        Cliente = model
                    });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteModel model, [FromServices] ClienteDomainService clienteDomainService)
        {
            try
            {
                var cliente = clienteDomainService.GetById(model.id);

                if (cliente != null)
                {
                    cliente.Nome = model.Nome;
                    cliente.Cpf = model.Cpf;
                    cliente.Telefone = model.Telefone;

                    clienteApplicationService.modify(model);
                    return Ok("Cliente atualizado com sucesso.");
                }
                else
                {
                    return UnprocessableEntity("Cliente não encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        [HttpDelete("{IdCliente}")]
        public IActionResult Delete(Guid idCliente, [FromServices] ClienteDomainService clienteDomainService)
        {
            try
            {
                var cliente = clienteDomainService.GetById(idCliente);

                clienteDomainService.Remove(cliente);

                return Ok("Cliente excluído com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromServices] ClienteDomainService clienteDomainService)
        {
            try
            {
                var lista = new List<Cliente>();

                foreach (var item in clienteDomainService.GetAll())
                {
                    var model = new Cliente();

                    model.Id = item.Id;
                    model.Nome = item.Nome;
                    model.Cpf = item.Cpf;
                    model.Telefone = item.Telefone;
                    model.Enderecos = item.Enderecos;

                    lista.Add(model);
                }

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
