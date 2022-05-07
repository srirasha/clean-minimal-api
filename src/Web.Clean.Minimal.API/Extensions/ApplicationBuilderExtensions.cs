namespace Web.Clean.Minimal.API.Extensions;
public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder EnableSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}