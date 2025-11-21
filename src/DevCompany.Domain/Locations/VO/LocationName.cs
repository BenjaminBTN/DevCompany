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

    public static Result<LocationName, Errors> Create(string value)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(value))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(LocationName)));

        if (value.Length < LengthConstants.LENGTH_3 || value.Length > LengthConstants.LENGTH_120)
            errors.Add(GeneralErrors.InvalidField(nameof(LocationName)));

        if (errors.Count != 0)
            return new Errors(errors);

        return new LocationName(value);
    }
}
