namespace DepartmentService.Shared;

public record Envelope
{
    public object? Result { get; }
    public Errors? Errors { get; }
    public DateTime TimeGenerated { get; }
    public bool IsError => Errors != null && Errors.Any();

    private Envelope(object? result, Errors? errors)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.UtcNow;
    }

    public static Envelope Ok(object? result)
        => new(result, null);

    public static Envelope Error(Errors errors)
        => new(null, errors);
}

public record Envelope<T>
{
    public T? Result { get; }
    public Errors? Errors { get; }
    public DateTime TimeGenerated { get; }
    public bool IsError => Errors != null || Errors!.Any();

    private Envelope(T? result, Errors? errors)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.UtcNow;
    }

    public static Envelope<T> Ok(T? result)
        => new(result, null);

    public static Envelope<T> Error(Errors errors)
        => new(default, errors);
}
