namespace DepartmentService.Shared;

public static class GeneralErrors
{
    public static Error InvalidField(string? invalidField = null)
    {
        string insert = invalidField == null ? string.Empty : ": " + invalidField;
        string message = $"Validation error, the value is invalid{insert}.";

        return Error.Validation("invalid.value", message, invalidField);
    }

    public static Error CannotBeEmpty(string? invalidField = null)
    {
        string insert = invalidField == null ? string.Empty : ": " + invalidField;
        string message = $"Validation error, the value cannot be empty{insert}.";

        return Error.Validation("invalid.value", message, invalidField);
    }

    public static Error NotFound(string? record = null)
    {
        string insert = record == null ? string.Empty : ": " + record;
        string message = $"Search error, the record was not found{insert}.";

        return Error.NotFound("record.not.found", message);
    }

    public static Error Conflict(string? record = null)
    {
        string insert = record == null ? string.Empty : ": " + record;
        string message = $"Record conflict, the record already exists{insert}.";

        return Error.Conflict("record.already.exists", message);
    }

    public static Error Failure()
    {
        return Error.Failure("server.error", "Internal server error.");
    }
}
