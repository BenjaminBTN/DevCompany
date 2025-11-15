using DevCompany.Contracts.Locations;
using DevCompany.Domain.Locations;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.VO;

namespace DevCompany.Application.Locations;

public class CreateLocationsHandler
{
    private readonly ILocationsRepository _repository;

    public CreateLocationsHandler(ILocationsRepository repository) => _repository = repository;

    public async Task<Guid> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var name = LocationName.Create(request.Name).Value;

        var address = Address.Create(
            request.Address.Country,
            request.Address.Region,
            request.Address.City,
            request.Address.Street,
            request.Address.HouseNumber,
            request.Address.PostalCode).Value;

        var timeZone = Timezone.Create(request.Timezone).Value;

        var location = Location.Create(name, address, timeZone).Value;

        return await _repository.Add(location, cancellationToken);
    }
}