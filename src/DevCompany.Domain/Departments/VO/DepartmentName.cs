using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace DevCompany.Domain.Departments.VO;

public record DepartmentName
{
    private DepartmentName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<DepartmentName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<DepartmentName>(nameof(DepartmentName) + " cannot be empty.");

        if (value.Length < 3 || value.Length > 150)
            return Result.Failure<DepartmentName>("Invalid " + nameof(DepartmentName) + " length.");

        return new DepartmentName(value);
    }
}