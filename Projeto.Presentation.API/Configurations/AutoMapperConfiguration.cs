using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.API.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
