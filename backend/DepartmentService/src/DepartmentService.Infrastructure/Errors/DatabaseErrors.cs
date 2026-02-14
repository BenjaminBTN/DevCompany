using DepartmentService.Shared;

namespace DepartmentService.Infrastructure.Errors;

public static class DatabaseErrors
{
    public static Error Unexpected(string? record = null, string[]? fields = null)
    {
        string args = fields == null || fields.Length == 0 
            ? string.Empty 
            : $" with fields: '{string.Join(", ", fields)}'";
        string insert = record == null ? string.Empty : " '" + record + "'" + args;
        return Error.Failure("database.error", $"Unexpected error when creating record{insert}.");
    }
}
