using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DevCompany.Shared;

namespace DevCompany.Domain.Departments.VO;

public record DepartmentPath
{
    public string Value { get; }

    private DepartmentPath(string value)
    {
        Value = value;
    }

    public static Result<DepartmentPath, Error> Create(string value)
    {
        if (Regex.Match(value, @"\w").Success == false)
            return GeneralErrors.InvalidField("DepartmentPath");

        return new DepartmentPath(value);
    }
}
