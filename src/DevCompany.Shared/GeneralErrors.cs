namespace DevCompany.Shared;

public class GeneralErrors
{
    public static Error Validation(string? invalidField = null)
    {
        string insert = invalidField == null ? string.Empty : ": " + invalidField;
        string message = $"Validation error. The field is invalid{insert}.";

        return Error.Validation("invalid.value", message, invalidField);
    }

    public static Error NotFound(string? record = null)
    {
        string insert = record == null ? string.Empty : ": " + record;
        string message = $"Search error. The record was not found{insert}.";

        return Error.NotFound("record.not.found", message);
    }

    public static Error Conflict(string? record = null)
    {
        string insert = record == null ? string.Empty : ": " + record;
        string message = $"Record conflict. The record already exists{insert}.";

        return Error.Conflict("record.already.exists", message);
    }

    public static Error Failure()
    {
        return Error.Failure("server.error", "Internal server error.");
    }
}
