using CSharpFunctionalExtensions;
using DevCompany.Contracts.Locations;
using DevCompany.Domain.Locations;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.VO;
using DevCompany.Shared;
using Microsoft.Extensions.Logging;

namespace DevCompany.Application.Locations;

public class CreateLocationsHandler
{
    private readonly ILocationsRepository _repository;
    private readonly ILogger<CreateLocationsHandler> _logger;

    public CreateLocationsHandler(ILocationsRepository repository, ILogger<CreateLocationsHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid, Errors>> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var nameResult = LocationName.Create(request.Name);
        if (nameResult.IsFailure)
        {
            _logger.LogError("No record has been created. {Message}", nameResult.Error.Message);
            return nameResult.Error.ToErrors();
        }
        var name = nameResult.Value;

        var addressResult = Address.Create(
            request.Address.Country,
            request.Address.Region,
            request.Address.City,
            request.Address.Street,
            request.Address.HouseNumber,
            request.Address.PostalCode);
        if(addressResult.IsFailure)
        {
            _logger.LogError(
                "No record has been created. {Message}", 
                string.Join(" ", addressResult.Error.Select(e => e.Message)));
            return addressResult.Error;
        }
        var address = addressResult.Value;

        var timeZoneResult = Timezone.Create(request.Timezone);
        if (timeZoneResult.IsFailure)
        {
            _logger.LogError("No record has been created. {Message}", timeZoneResult.Error.Message);
            return timeZoneResult.Error.ToErrors();
        }
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

        Guid id = await _repository.Add(location, cancellationToken);
        _logger.LogInformation("A new Location has been created with ID: {id}.", id);

        return id;
    }
}
