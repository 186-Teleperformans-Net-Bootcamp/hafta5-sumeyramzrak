using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teleperformance.Odev4.Common;
using Teleperformance.Odev4.Data.Context;


namespace ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection($"{nameof(Settings) }:Database");
            var settings = section.Get<Settings.DatabaseConfiguration>();
            services.AddDbContext<TlpDbContext>(builder =>
            {
                builder.UseSqlServer(settings.ConnectionString);
            });

            return services;
        }

    } 
}
