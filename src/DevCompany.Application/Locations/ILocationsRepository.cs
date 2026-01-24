using CSharpFunctionalExtensions;
using DevCompany.Domain.Locations;
using DevCompany.Shared;

namespace DevCompany.Application.Locations;

public interface ILocationsRepository
{
    Task<Result<Guid, Error>> Add(Location location, CancellationToken cancellationToken = default);
}
