using AutoMapper;
using Projeto.Domain.Entities;
using ProjetoApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        //construtor
        public ViewModelToEntityMap()
        {
            CreateMap<ClienteModel, Cliente>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.Nome = src.Nome;
                });

            CreateMap<EnderecoModel, Endereco>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                });
        }
    }
}
