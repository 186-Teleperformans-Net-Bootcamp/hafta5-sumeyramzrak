namespace Teleperformance.Odev4.Data
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

