using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoApplication.ViewModels
{
    public class ClienteModel
    {
        public Guid id { get; set; }
        [Required(ErrorMessage = "Informe o nome do cliente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o cpf do cliente.")]
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = "Endereço de email inválido.")]
        [Required(ErrorMessage = "Informe o email do cliente.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o telefone do cliente.")]
        public string Telefone { get; set; }

        public List<EnderecoModel> Enderecos { get; set; }
    }
}
