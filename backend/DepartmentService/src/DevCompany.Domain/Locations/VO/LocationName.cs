using CSharpFunctionalExtensions;
using DepartmentService.Domain.Shared.Constants;
using DepartmentService.Shared;

namespace DepartmentService.Domain.Locations.VO;

public record LocationName
{
    private LocationName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<LocationName, Errors> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return GeneralErrors.CannotBeEmpty(nameof(LocationName)).ToErrors();

        if (value.Length < LengthConstants.LENGTH_3 || value.Length > LengthConstants.LENGTH_120)
            return GeneralErrors.InvalidField(nameof(LocationName)).ToErrors();

        return new LocationName(value);
    }
}
