using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
            .HasMaxLength(150)
            .IsRequired();

            builder.Property(c => c.Cpf)
            .HasMaxLength(14)
            .IsRequired();

            builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.Telefone)
            .HasMaxLength(20)
            .IsRequired();
        }
    }
}
