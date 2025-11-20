using DevCompany.Application.Locations;
using DevCompany.Contracts.Locations;
using DevCompany.Presentation.EndpointResults;
using Microsoft.AspNetCore.Mvc;

namespace DevCompany.Presentation.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<EndpointResult<Guid>> Create(
        [FromServices] CreateLocationsHandler handler,
        [FromBody] CreateLocationRequest request,
        CancellationToken cancellationToken)
    {
        return await handler.Handle(request, cancellationToken);
    }
}
