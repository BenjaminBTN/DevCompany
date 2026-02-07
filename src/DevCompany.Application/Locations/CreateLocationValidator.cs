using DevCompany.Application.Validators;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.VO;
using FluentValidation;

namespace DevCompany.Application.Locations;

public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationValidator()
    {
        RuleFor(c => c.Request.Name)
            .MustBeValueObject(LocationName.Create);

        RuleFor(c => c.Request.Address)
            .MustBeValueObject(a => Address.Create(a.Country, a.Region, a.City, a.Street, a.HouseNumber, a.PostalCode));

        RuleFor(c => c.Request.Timezone)
            .MustBeValueObject(Timezone.Create);
    }
}
