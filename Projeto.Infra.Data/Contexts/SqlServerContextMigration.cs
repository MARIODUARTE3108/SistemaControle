using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    public class SqlServerContextMigration : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            #region Ler a connectionstring mapeada no appsettings.json

            var builder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            builder.AddJsonFile(path);

            var root = builder.Build();
            var connectionString = root.GetSection("ConnectionStrings")
                .GetSection("ProjetoDDD").Value;

            #endregion

            #region Configurando o Migrations

            var options = new DbContextOptionsBuilder<SqlServerContext>();
            options.UseSqlServer(connectionString);

            return new SqlServerContext(options.Options);

            #endregion
        }
    }
}
