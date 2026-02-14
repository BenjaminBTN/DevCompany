using CSharpFunctionalExtensions;
using DepartmentService.Application.Locations;
using DepartmentService.Domain.EntityErrors;
using DepartmentService.Domain.Locations;
using DepartmentService.Infrastructure.Configurations;
using DepartmentService.Infrastructure.Errors;
using DepartmentService.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DepartmentService.Infrastructure.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly DirectoryServiceDbContext _dbContext;
    private readonly ILogger<LocationsRepository> _logger;

    public LocationsRepository(DirectoryServiceDbContext dbContext, ILogger<LocationsRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Add(Location location, CancellationToken cancellationToken)
    {
        _dbContext.Locations.Add(location);

        try
        {
            await _dbContext.SaveChangesAsync(cancellationToken);

        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx)
        {
            if (pgEx.SqlState == PostgresErrorCodes.UniqueViolation && pgEx.ConstraintName != null)
            {
                if (pgEx.ConstraintName.Contains(LocationIndex.NAME, StringComparison.InvariantCultureIgnoreCase))
                {
                    var error = LocationErrors.NameConflict(location.Name.Value, nameof(location.Name));
                    _logger.LogError(ex, "{message}", error.Message);
                    return error;
                }
                if (pgEx.ConstraintName.Contains(LocationIndex.ADDRESS, StringComparison.InvariantCultureIgnoreCase))
                {
                    var error = LocationErrors.AddressConflict(location.Address.ToString(), nameof(location.Address));
                    _logger.LogError(ex, "{message}", error.Message);
                    return error;
                }
            }
        }
        catch (Exception ex)
        {
            var error = DatabaseErrors.Unexpected(nameof(Location), ["Name"]);
            _logger.LogError(ex, "{message}", error.Message);
            return error;
        }
        return location.Id.Value;
    }
}
