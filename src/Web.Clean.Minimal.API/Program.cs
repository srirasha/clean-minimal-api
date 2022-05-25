using Application;
using Application.Avatars.Queries.GetAvatarById;
using Application.Avatars.Queries.GetAvatars;
using CSharpFunctionalExtensions;
using Domain.Assets;
using Infrastructure;
using Infrastructure.Extensions;
using Infrastructure.Middlewares;
using MediatR;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.UseSerilog();
builder.AddSwagger();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder);

WebApplication app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.EnableSwagger();

if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}

#region Avatars

app.MapGet("api/avatars", (IMediator mediator, CancellationToken cancellationToken) =>
{
    return mediator.Send(new GetAvatarsQuery(), cancellationToken);
})
.WithName("GetAvatars")
.WithTags("Avatars")
.Produces<IEnumerable<Avatar>>();

app.MapGet("api/avatars/{id}", async (IMediator mediator, string id, CancellationToken cancellationToken) =>
{
    Maybe<Avatar> maybeAvatar = await mediator.Send(new GetAvatarByIdQuery(id), cancellationToken);

    return maybeAvatar.HasValue ? Results.Ok(maybeAvatar.Value) : Results.NotFound();
})
.WithName("GetAvatarById")
.WithTags("Avatars")
.Produces<Avatar>()
.Produces(StatusCodes.Status404NotFound);

#endregion

app.MapGet("healthcheck", () => { return new { Message = "I am alive!" }; })
.ExcludeFromDescription();

app.Run();