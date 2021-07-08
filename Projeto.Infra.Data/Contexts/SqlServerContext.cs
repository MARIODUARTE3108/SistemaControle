using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> EnderecoCliente { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());

            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasIndex(c => c.Email).IsUnique();
                c.HasIndex(c => c.Cpf).IsUnique();
            });
        }
    }
}
