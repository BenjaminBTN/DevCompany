using CSharpFunctionalExtensions;
using DepartmentService.Domain.Locations;
using DepartmentService.Shared;

namespace DepartmentService.Application.Locations;

public interface ILocationsRepository
{
    Task<Result<Guid, Error>> Add(Location location, CancellationToken cancellationToken = default);
}
