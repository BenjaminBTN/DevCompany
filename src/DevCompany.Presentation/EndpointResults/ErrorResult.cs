using DevCompany.Shared;

namespace DevCompany.Presentation.EndpointResults;

public class ErrorResult : IResult
{
    private readonly Errors _errors;

    public ErrorResult(Errors errors) => _errors = errors;
    public ErrorResult(Error error) => _errors = error.ToErrors();

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        httpContext.Response.StatusCode = GetStatusCode();
        var envelope = Envelope.Error(_errors);
        return httpContext.Response.WriteAsJsonAsync(envelope);
    }

    private int GetStatusCode()
    {
        int code = StatusCodes.Status500InternalServerError;

        var errorType = _errors.Select(
            e => e.Type)
            .Distinct()
            .ToList();

        if (errorType.Count > 1 || errorType.Count < 1)
            return code;

        code = errorType.First() switch
        {
            ErrorType.VALIDATION => StatusCodes.Status400BadRequest,
            ErrorType.NOT_FOUND => StatusCodes.Status404NotFound,
            ErrorType.CONFLICT => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };

        return code;
    }
}
