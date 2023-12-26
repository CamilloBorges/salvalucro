using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace SalvaLucro
{
    public static class SalvaLucroHostBuilderExtensions
    {

        public static IHostBuilder UseSalvaLucro(this IHostBuilder builder, [NotNull] Action<SalvaLucroOptions> configureOptions)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            if (configureOptions == null)
            {
                throw new ArgumentNullException("configureOptions");
            }
            builder.ConfigureServices(delegate (HostBuilderContext _, IServiceCollection collection)
            {
                collection.AddSalvaLucro(configureOptions);
            });
            return builder;
        }
    }
}
