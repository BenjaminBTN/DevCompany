using CSharpFunctionalExtensions;

namespace DevCompany.Domain.Locations.VO;

public class LocationName
{
    private LocationName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<LocationName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<LocationName>(nameof(LocationName) + " cannot be empty.");

        if (value.Length < 3 || value.Length > 120)
            return Result.Failure<LocationName>("Invalid " + nameof(LocationName) + " length.");

        return new LocationName(value);
    }
}