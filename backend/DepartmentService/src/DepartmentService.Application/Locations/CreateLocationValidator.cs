using DepartmentService.Application.Validators;
using DepartmentService.Domain.Locations.VO;
using DepartmentService.Domain.Shared.VO;
using FluentValidation;

namespace DepartmentService.Application.Locations;

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
