using CSharpFunctionalExtensions;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.Constants;
using DevCompany.Shared;

namespace DevCompany.Domain.Positions.VO;

public record PositionName
{
    private PositionName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<PositionName, Errors> Create(string value)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(value))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(PositionName)));

        if (value.Length < LengthConstants.LENGTH_3 || value.Length > LengthConstants.LENGTH_100)
            errors.Add(GeneralErrors.InvalidField(nameof(LocationName)));

        if (errors.Count != 0)
            return new Errors(errors);

        return new PositionName(value);
    }
}
