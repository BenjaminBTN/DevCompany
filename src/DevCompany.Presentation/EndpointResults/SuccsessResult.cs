using DevCompany.Shared;

namespace DevCompany.Presentation.EndpointResults;

public sealed class SuccsessResult<TValue> : IResult
{
    private readonly TValue _value;

    public SuccsessResult(TValue value) => _value = value;

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        httpContext.Response.StatusCode = StatusCodes.Status200OK;

        var envelope = Envelope.Ok(_value);

        return httpContext.Response.WriteAsJsonAsync(envelope);
    }
}
