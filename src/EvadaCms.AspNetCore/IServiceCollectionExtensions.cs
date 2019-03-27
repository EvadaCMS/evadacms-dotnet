using Evada;
using Evada.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Evada.AspNetCore
{
    public static class IServiceCollectionExtensions
    {
        private const string EvadaHttpClientName = "EvadaClient";

        public static IServiceCollection AddEvada(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<EvadaOptions>(configuration.GetSection("EvadaOptions"));
            services.TryAddSingleton<HttpClient>();
            services.AddHttpClient(EvadaHttpClientName);
            services.TryAddTransient<IEvadaClient>(serviceProvider =>
            {
                var options = serviceProvider.GetService<IOptions<EvadaOptions>>().Value;
                var factory = serviceProvider.GetService<IHttpClientFactory>();
                return new EvadaClient(factory.CreateClient(EvadaHttpClientName), options);
            });

            return services;
        }
    }
}
