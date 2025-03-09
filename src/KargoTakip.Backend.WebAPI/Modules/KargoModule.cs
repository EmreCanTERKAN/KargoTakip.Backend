using KargoTakip.Backend.Application.Kargolarim;
using KargoTakip.Backend.Domain.Kargolarim;
using MediatR;
using TS.Result;

namespace KargoTakip.Backend.WebAPI.Modules;

public static class KargoModule
{
    public static void RegisterKargoRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/kargolarim").WithTags("Kargolarim").RequireAuthorization();

        group.MapGet("{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new KargoGetQuery(id), cancellationToken);
            return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
        })
        .Produces<Result<Kargo>>()
        .WithName("KargoGet");

        group.MapPost(string.Empty,
            async (ISender sender, KargoCreateCommand request, CancellationToken cancellationToken) =>
            {
                var response = await sender.Send(request, cancellationToken);
                return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
            })
            .Produces<Result<string>>()
            .WithName("KargoCreate");

        group.MapPut(string.Empty,
            async (ISender sender, KargoUpdateCommand request, CancellationToken cancellationToken) =>
            {
                var response = await sender.Send(request, cancellationToken);
                return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError   (response);
            })
            .Produces<Result<string>>()
            .WithName("KargoUpdate");

        group.MapDelete("{id}"
            , async (Guid id, ISender sender,CancellationToken cancellationToken) =>
            {
                var response = await sender.Send(new KargoDeleteCommand(id), cancellationToken);
                return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
            }
            )
            .Produces<Result<string>>()
            .WithName("KargoDelete");
    }
}
