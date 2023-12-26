using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalvaLucro.Domain.Services;
using SalvaLucro.Services;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace SalvaLucro
{
    public static class SalvaLucroServiceCollectionExtensions
    {
        public static IServiceCollection AddSalvaLucro([NotNull] this IServiceCollection services, [NotNull] Action<SalvaLucroOptions> configureOptions)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException("configureOptions");
            }

            services.ConfigureOptions<SalvaLucroOptionsSetup>();
            services.AddSingleton<IConnectionService, ConnectionService>();
            services.AddSingleton<IVendasService, VendasService>();
            services.AddSingleton<IAjustesService, AjustesService>();

            return services;
        }

    }
}