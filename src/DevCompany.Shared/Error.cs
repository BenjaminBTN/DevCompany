namespace DevCompany.Shared;

public class Error
{
    private Error(ErrorType type, string code, string message, string? invalidValue = null)
    {
        Type = type;
        Code = code;
        Message = message;
        InvalidField = invalidValue;
    }

    public ErrorType Type { get; }
    public string Code { get; }
    public string Message { get; }
    public string? InvalidField { get; }

    public static Error Validation(string code, string message, string? invalidField = null) 
        => new(ErrorType.VALIDATION, code, message, invalidField);

    public static Error NotFound(string code, string message)
        => new(ErrorType.NOT_FOUND, code, message);

    public static Error Conflict(string code, string message)
        => new(ErrorType.CONFLICT, code, message);

    public static Error Failure(string code, string message)
        => new(ErrorType.FAILURE, code, message);

    public Errors ToErrors()
        => new([this]);
}

public enum ErrorType
{
    VALIDATION,
    NOT_FOUND,
    CONFLICT,
    FAILURE,
}