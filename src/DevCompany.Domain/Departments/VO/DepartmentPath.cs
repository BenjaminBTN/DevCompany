using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace DevCompany.Domain.Departments.VO;

public record DepartmentPath
{
    public string Value { get; }

    private DepartmentPath(string value)
    {
        Value = value;
    }

    public static Result<DepartmentPath> Create(string value)
    {
        if (Regex.Match(value, @"\w").Success == false)
            return Result.Failure<DepartmentPath>("Invalid " + nameof(DepartmentPath) + ".");

        return new DepartmentPath(value);
    }
}