namespace Web.Clean.Minimal.API.Extensions;
public static class ApplicationBuilderExtensions
{
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