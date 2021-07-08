using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);
        }
    }
}
