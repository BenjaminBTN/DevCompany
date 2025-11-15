using DevCompany.Domain.Locations;

namespace DevCompany.Application.Locations;

public interface ILocationsRepository
{
    Task<Guid> Add(Location location, CancellationToken cancellationToken = default);
}