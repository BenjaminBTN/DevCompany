namespace DevCompany.Shared;

public class Error
{
    private const string SEPARATOR = "||";

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

    public static Error Conflict(string code, string message, string? invalidField = null)
        => new(ErrorType.CONFLICT, code, message, invalidField);

    public static Error Failure(string code, string message)
        => new(ErrorType.FAILURE, code, message);

    #region Дополнительные методы
    public Errors ToErrors()
        => new([this]);

    public string Serialize()
    {
        return string.Join(SEPARATOR, Type.ToString(), Code, Message, InvalidField ?? string.Empty);
    }

    public static Error Deserialize(string serializedSting)
    {
        if (string.IsNullOrWhiteSpace(serializedSting))
            throw new ArgumentNullException(nameof(serializedSting));

        string[] parts = serializedSting.Split(SEPARATOR);

        if (parts.Length < 3 || parts.Length > 4)
            throw new ArgumentOutOfRangeException(nameof(serializedSting));

        if (Enum.TryParse<ErrorType>(parts[0], out var type) == false)
            throw new ArgumentException("Invalid serialized format");

        return new Error(type, parts[1], parts[2], parts.Length == 4 ? parts[3] : null);
    }
    #endregion
}

public enum ErrorType
{
    VALIDATION,
    NOT_FOUND,
    CONFLICT,
    FAILURE,
}
