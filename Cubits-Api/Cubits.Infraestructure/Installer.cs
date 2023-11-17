
using Cubits.Domain.Ports;
using Cubits.Infraestructure.Database;
using Cubits.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Cubits.Infraestructure
{
    public static class Installer
    {
        public static void InstallRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(30);
                    sqlServerOptions.EnableRetryOnFailure();
                    sqlServerOptions.MigrationsHistoryTable("_Migrations");
                    sqlServerOptions.MigrationsAssembly("Cubits.Infraestructure");
                });
            });
        }
    }
}
