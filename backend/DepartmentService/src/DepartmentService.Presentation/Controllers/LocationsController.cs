using DepartmentService.Application.Locations;
using DepartmentService.Contracts.Locations;
using Microsoft.AspNetCore.Mvc;
using Shared.Framework.EndpointResults;

namespace DepartmentService.Presentation.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<EndpointResult<Guid>> Create(
        [FromServices] CreateLocationHandler handler,
        [FromBody] CreateLocationRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateLocationCommand(request);
        return await handler.Handle(command, cancellationToken);
    }
}
