using DevCompany.Shared;
using FluentValidation.Results;

namespace DevCompany.Application.Validators;

public static class ValidationExtensions
{
    public static Errors ToErrors(this ValidationResult validationResult)
    {
        var validationFailures = validationResult.Errors;

        var errors =
            from failure in validationFailures
            let error = Errors.Deserialize(failure.ErrorMessage)
            select error;

        return new Errors(errors.SelectMany(i => i));
    }
}
