using CSharpFunctionalExtensions;
using DepartmentService.Shared;
using FluentValidation;

namespace DepartmentService.Application.Validators;

public static class CustomValidators
{
    public static IRuleBuilderOptionsConditions<T, TProperty> MustBeValueObject<T, TProperty, TValueObject>(
        this IRuleBuilder<T, TProperty> ruleBuilder,
        Func<TProperty, Result<TValueObject, Errors>> factoryMethod)
    {
        return ruleBuilder.Custom((value, context) => {
            var result = factoryMethod(value);
            if (result.IsFailure)
                context.AddFailure(result.Error.Serialize());
        });
    }

    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule, Errors errors)
    {
        return rule.WithMessage(errors.Serialize());
    }
}
