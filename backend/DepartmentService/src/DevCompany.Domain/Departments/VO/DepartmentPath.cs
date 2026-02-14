using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DepartmentService.Shared;

namespace DepartmentService.Domain.Departments.VO;

public record DepartmentPath
{
    public string Value { get; }

    private DepartmentPath(string value)
    {
        Value = value;
    }

    public static Result<DepartmentPath, Errors> Create(string value)
    {
        if (Regex.Match(value, @"\w").Success == false)
            return GeneralErrors.InvalidField("DepartmentPath").ToErrors();

        return new DepartmentPath(value);
    }
}
