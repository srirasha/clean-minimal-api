using Application._Common.Repositories;
using Infrastructure.Persistence.Contexts.AssetsDb;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSingleton<IAssetsContext, AssetsContext>();
            services.AddSingleton<IAvatarsRepository, AvatarsRepository>();
        }
    }
}