using CSharpFunctionalExtensions;
using DevCompany.Shared;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace DevCompany.Presentation.EndpointResults;

public class EndpointResult<TValue> : IResult
{
    public readonly IResult _result;

    public EndpointResult(Result<TValue, Errors> result)
    {
        _result = result.IsSuccess
            ? new SuccsessResult<TValue>(result.Value)
            : new ErrorResult(result.Error);
    }

    public EndpointResult(Result<TValue, Error> result)
    {
        _result = result.IsSuccess
            ? new SuccsessResult<TValue>(result.Value)
            : new ErrorResult(result.Error);
    }

    public Task ExecuteAsync(HttpContext httpContext) 
        => _result.ExecuteAsync(httpContext);

    public static implicit operator EndpointResult<TValue>(Result<TValue, Errors> result)
        => new(result);

    public static implicit operator EndpointResult<TValue>(Result<TValue, Error> result)
        => new(result);
}
