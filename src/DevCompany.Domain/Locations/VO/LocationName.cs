using CSharpFunctionalExtensions;
using DevCompany.Domain.Shared.Constants;
using DevCompany.Shared;

namespace DevCompany.Domain.Locations.VO;

public class LocationName
{
    private LocationName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<LocationName, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return GeneralErrors.CannotBeEmpty(nameof(LocationName));

        if (value.Length < LengthConstants.LENGTH_3 || value.Length > LengthConstants.LENGTH_120)
            return GeneralErrors.InvalidField(nameof(LocationName));

        return new LocationName(value);
    }
}
