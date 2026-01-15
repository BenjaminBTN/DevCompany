using DevCompany.Application.Validators;
using DevCompany.Domain.Locations.VO;
using DevCompany.Shared;
using FluentValidation;

namespace DevCompany.Application.Locations;

public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationValidator()
    {
        //RuleFor(c => c.Request)
        //    .NotNull().WithError(GeneralErrors.CannotBeEmpty("Request").ToErrors());

        RuleFor(c => c.Request.Name)
            .MustBeValueObject(LocationName.Create);
    }
}
