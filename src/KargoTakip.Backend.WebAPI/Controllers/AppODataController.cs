using KargoTakip.Backend.Application.Kargolarim;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace KargoTakip.Backend.WebAPI.Controllers;

[Route("odata")]
[ApiController]
[EnableQuery]
public class AppODataController(
    ISender sender
    ) : ODataController
{
    public static IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new();
        builder.EnableLowerCamelCase();
        builder.EntitySet<KargoGetAllQueryResponse>("kargolarim");
        return builder.GetEdmModel();
    }

    [HttpGet("kargolarim")]
    public async Task<IQueryable<KargoGetAllQueryResponse>> GetAllKargo(CancellationToken cancellationToken)
    {
        var response = await sender.Send(new KargoGetAllQuery(), cancellationToken);
        return response;
    }
}
