using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.API.Configurations
{
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFrameworkSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProjetoDDD");

            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));
        }
    }
}
