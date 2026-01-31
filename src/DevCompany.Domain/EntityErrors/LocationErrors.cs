using DevCompany.Shared;

namespace DevCompany.Domain.EntityErrors;

public static class LocationErrors
{
    public static Error NameConflict(string title)
        => Error.Conflict("location.name.conflict", $"The location with the name '{title}' already exists.");
}
