using CSharpFunctionalExtensions;
using DevCompany.Application.Abstractions;
using DevCompany.Application.Validators;
using DevCompany.Domain.Locations;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.VO;
using DevCompany.Shared;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevCompany.Application.Locations;

public class CreateLocationHandler : ICommandHandler<Guid, CreateLocationCommand>
{
    private readonly ILocationsRepository _repository;
    private readonly IValidator<CreateLocationCommand> _validator;
    private readonly ILogger<CreateLocationHandler> _logger;

    public CreateLocationHandler(ILocationsRepository repository, ILogger<CreateLocationHandler> logger, IValidator<CreateLocationCommand> validator)
    {
        _repository = repository;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Result<Guid, Errors>> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(command);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToErrors();
        }

        var nameResult = LocationName.Create(command.Request.Name);
        if (nameResult.IsFailure)
        {
            _logger.LogError("No record has been created. {Message}", string.Join(" ", nameResult.Error.Select(e => e.Message)));
            return nameResult.Error;
        }
        var name = nameResult.Value;

        var addressResult = Address.Create(
            command.Request.Address.Country,
            command.Request.Address.Region,
            command.Request.Address.City,
            command.Request.Address.Street,
            command.Request.Address.HouseNumber,
            command.Request.Address.PostalCode);
        if(addressResult.IsFailure)
        {
            _logger.LogError(
                "No record has been created. {Message}", 
                string.Join(" ", addressResult.Error.Select(e => e.Message)));
            return addressResult.Error;
        }
        var address = addressResult.Value;

        var timeZoneResult = Timezone.Create(command.Request.Timezone);
        if (timeZoneResult.IsFailure)
        {
            _logger.LogError("No record has been created. {Message}", string.Join(" ", timeZoneResult.Error.Select(e => e.Message)));
            return timeZoneResult.Error;
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

        var addLocationResult = await _repository.Add(location, cancellationToken);
        if (addLocationResult.IsFailure)
            return addLocationResult.Error.ToErrors();
        Guid id = addLocationResult.Value;
        _logger.LogInformation("A new Location has been created with ID: {id}.", id);

        return id;
    }
}
