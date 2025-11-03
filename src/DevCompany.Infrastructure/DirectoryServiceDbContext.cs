using DevCompany.Domain.Departments;
using DevCompany.Domain.Locations;
using DevCompany.Domain.Positions;
using Microsoft.EntityFrameworkCore;

namespace DevCompany.Infrastructure;

public class DirectoryServiceDbContext : DbContext
{
    private readonly string _connectionString;

    public DirectoryServiceDbContext(string connectionString) => _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryServiceDbContext).Assembly);
    }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<DepartmentLocation> DepartmentLocation => Set<DepartmentLocation>();
    public DbSet<DepartmentPosition> DepartmentPosition => Set<DepartmentPosition>();
}