using CSharpFunctionalExtensions;

namespace DevCompany.Domain.Positions.VO;

public record PositionName
{
    private PositionName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<PositionName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<PositionName>(nameof(PositionName) + " cannot be empty.");

        if (value.Length < 3 || value.Length > 100)
            return Result.Failure<PositionName>("Invalid " + nameof(PositionName) + " length.");

        return new PositionName(value);
    }
}