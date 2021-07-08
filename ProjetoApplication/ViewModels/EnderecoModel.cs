using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoApplication.ViewModels
{
    public class EnderecoModel
    {
        [Required(ErrorMessage = "Informe o logradouro.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o número.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o complemento.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe o cep.")]
        public string Cep { get; set; }
    }
}
