using CSharpFunctionalExtensions;
using DevCompany.Contracts.Locations;
using DevCompany.Domain.Locations;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.VO;
using DevCompany.Shared;

namespace DevCompany.Application.Locations;

public class CreateLocationsHandler
{
    private readonly ILocationsRepository _repository;

    public CreateLocationsHandler(ILocationsRepository repository) => _repository = repository;

    public async Task<Result<Guid, Errors>> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var nameResult = LocationName.Create(request.Name);
        if (nameResult.IsFailure)
            return nameResult.Error;
        var name = nameResult.Value;

        var addressResult = Address.Create(
            request.Address.Country,
            request.Address.Region,
            request.Address.City,
            request.Address.Street,
            request.Address.HouseNumber,
            request.Address.PostalCode);
        if (addressResult.IsFailure)
            return addressResult.Error;
        var address = addressResult.Value;

        var timeZoneResult = Timezone.Create(request.Timezone);
        if (timeZoneResult.IsFailure)
            return timeZoneResult.Error.ToErrors();
        var timeZone = timeZoneResult.Value;

        bool isActive = true;
        DateTime createdAt = DateTime.UtcNow;
        DateTime updatedAt = createdAt;

        var location = new Location(
            LocationId.New(),
            name,
            address,
            timeZone,
            isActive,
            createdAt,
            updatedAt);

        return await _repository.Add(location, cancellationToken);
    }
}
