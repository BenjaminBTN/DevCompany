using CSharpFunctionalExtensions;
using DevCompany.Domain.Shared.Constants;
using DevCompany.Shared;

namespace DevCompany.Domain.Departments.VO;

public record DepartmentName
{
    private DepartmentName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<DepartmentName, Errors> Create(string value)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(value))
            errors.Add(GeneralErrors.CannotBeEmpty(nameof(DepartmentName)));

        if (value.Length < LengthConstants.LENGTH_3 || value.Length > LengthConstants.LENGTH_150)
            errors.Add(GeneralErrors.InvalidField(nameof(DepartmentName)));

        if (errors.Count != 0)
            return new Errors(errors);

        return new DepartmentName(value);
    }
}
