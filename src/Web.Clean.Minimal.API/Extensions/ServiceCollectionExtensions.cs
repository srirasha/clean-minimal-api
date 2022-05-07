using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Web.Clean.Minimal.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
                                                  .Enrich.WithExceptionDetails()
                                                  .WriteTo.Console()
                                                  .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration["Elastic:Uri"]))
                                                  {
                                                      AutoRegisterTemplate = true,
                                                      IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{DateTime.UtcNow:yyyy}"
                                                  })
                                                  .CreateLogger();
            builder.Host.UseSerilog();

            return builder;
        }

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
    }
}