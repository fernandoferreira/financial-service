using Financial.Services.OpenBank.Core.Domain;
using Financial.Services.OpenBank.Infra.Cache;
using Financial.Services.OpenBank.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Services.OpenBank.Infra
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddCache();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Account>, AccountRepository>();
            services.AddSingleton<IRepository<Client>, ClientRepository>();

            return services;
        }

        public static IServiceCollection AddCache(this IServiceCollection services)
        {
            services.AddSingleton<ICustomMemoryCache, CustomMemoryCache>();
            return services;
        }
    }
}

