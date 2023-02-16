using Financial.Services.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Services.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            return services;
        }
    }
}

