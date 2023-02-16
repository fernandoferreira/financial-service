using System;
using Financial.Services.OpenBank.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Services.OpenBank.Infra.Repositories
{
    public static class InfrastructureModule
    {
       public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Account>, AccountRepository>();
            services.AddSingleton<IRepository<Client>, ClientRepository>();

            return services;
        }
    }
}

