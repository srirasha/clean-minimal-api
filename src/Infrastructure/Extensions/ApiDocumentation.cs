using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Infrastructure.Extensions
{
    public static class ApiDocumentation
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwagger();

            return builder;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Description = "Clean minimal API",
                    Title = "Clean minimal API presentation",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Shahrukh Khan",
                        Url = new Uri("https://gitlab.com/srirasha")
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder EnableSwagger(this WebApplication app)
        {
            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}