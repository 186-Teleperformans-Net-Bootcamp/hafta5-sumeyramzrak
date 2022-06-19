using Microsoft.Extensions.DependencyInjection;
using Teleperformance.Odev4.Services.Abstractions;
using Teleperformance.Odev4.Services.Concretes;

namespace Teleperformance.Odev4.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }

    }
}
