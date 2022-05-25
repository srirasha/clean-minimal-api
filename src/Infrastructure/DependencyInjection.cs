using Application._Common.Repositories;
using Infrastructure.Persistence.Contexts.AssetsDb;
using Infrastructure.Persistence.Contexts.AssetsDb.Configurations;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, WebApplicationBuilder webApplicationBuilder)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddServices();
            services.AddConfigurations(webApplicationBuilder);
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IAssetsContext, AssetsContext>();
            services.AddSingleton<IAvatarsRepository, AvatarsRepository>();
        }

        private static void AddConfigurations(this IServiceCollection services, WebApplicationBuilder webApplicationBuilder)
        {
            services.Configure<AssetsDbConfiguration>(webApplicationBuilder.Configuration.GetSection("AssetsDb"));
        }
    }
}