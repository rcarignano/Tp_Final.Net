
using Cubits.Domain.Ports;
using Cubits.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Cubits.Infraestructure
{
    public static class Installer
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
