using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DevCompany.Domain.Departments.VO;

namespace DevCompany.Domain.Departments;

public class Department
{
    private Department(
        Guid id,
        DepartmentName name,
        string identifier,
        Guid? parentId,
        DepartmentPath path,
        short depth,
        bool isActive,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
        IsActive = isActive;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Guid Id { get; private set; }
    public DepartmentName Name { get; private set; }
    public string Identifier { get; private set; } = string.Empty;
    public Guid? ParentId { get; private set; }
    public DepartmentPath Path { get; private set; }
    public short Depth { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public static Result<Department> Create(
        DepartmentName name,
        string identifier,
        Guid? parentId,
        DepartmentPath path,
        short depth,
        bool isActive)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            return Result.Failure<Department>("Identifier cannot be empty.");

        if (depth < 0)
            return Result.Failure<Department>("Depth cannot be less then zero.");

        var id = Guid.NewGuid();
        DateTime createdAt = DateTime.Now;
        DateTime updatedAt = createdAt;

        return new Department(id, name, identifier, parentId, path, depth, isActive, createdAt, updatedAt);
    }
}