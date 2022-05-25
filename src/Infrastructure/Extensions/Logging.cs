using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class Logging
    {
        public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
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

            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

            return builder;
        }
    }
}