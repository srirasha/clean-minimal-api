using Application;
using Application.Avatars.Queries.GetAvatarById;
using Application.Avatars.Queries.GetAvatars;
using Infrastructure;
using Infrastructure.Persistence.Contexts.AssetsDb.Configurations;
using MediatR;
using Serilog;
using Web.Clean.Minimal.API.Extensions;
using Web.Clean.Minimal.API.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
builder.AddSwagger();

builder.Services.Configure<AssetsDbConfiguration>(builder.Configuration.GetSection("AssetsDb"));

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

WebApplication app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.EnableSwagger();

app.MapGet("api/v1/avatars", (IMediator mediator, CancellationToken cancellationToken) =>
{
    return mediator.Send(new GetAvatarsQuery(), cancellationToken);
})
.WithName("GetAvatars")
.WithTags("Avatars");

app.MapGet("api/v1/avatars/{id}", async (IMediator mediator, string id, CancellationToken cancellationToken) =>
 {
     await mediator.Send(new GetAvatarByIdQuery(id), cancellationToken);
 })
.WithName("GetAvatarById")
.WithTags("Avatars");

app.Run();