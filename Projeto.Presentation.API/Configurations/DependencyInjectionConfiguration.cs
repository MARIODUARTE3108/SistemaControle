using Microsoft.Extensions.DependencyInjection;
using Projeto.Domain.Contracts.Data;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Repositories;
using ProjetoApplication.Contracts;
using ProjetoApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            #region Application Layer

            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();

            #endregion

            #region Domain Layer

            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IEnderecoDomainService, EnderecoDomainService>();

            #endregion

            #region InfraStructure Layer

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion
        }
    }
}
