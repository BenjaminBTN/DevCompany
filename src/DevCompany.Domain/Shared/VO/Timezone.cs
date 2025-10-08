using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DevCompany.Domain.Shared.VO;

public record Timezone
{
    public const string IANA_PATTERN = "([a-zA-Z0-9_])(\\/[a-zA-Z0-9_]+)";

    public string Value { get; }

    private Timezone(string value)
    {
        Value = value;
    }

    public static Result<Timezone> Create(string value)
    {
        if (Regex.Match(value, IANA_PATTERN).Success == false)
            return Result.Failure<Timezone>("Invalid " + nameof(Timezone) + ".");

        return new Timezone(value);
    }
}