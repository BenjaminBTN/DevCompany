using DevCompany.Shared;

namespace DevCompany.Domain.EntityErrors;

public static class LocationErrors
{
    public static Error NameConflict(string title, string? invalidField = null)
        => Error.Conflict(
            "create.location.conflict", 
            $"The location with the name '{title}' already exists.", 
            invalidField);

    public static Error AddressConflict(string title, string? invalidField = null)
        => Error.Conflict(
            "create.location.conflict", 
            $"The address with these parameters '{title}' already exists.", 
            invalidField);
}
