using DepartmentService.Domain.Departments;
using DepartmentService.Domain.Departments.VO;
using DepartmentService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepartmentService.Infrastructure.Configurations;

public class DepartmentLocationConfig : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");

        builder.HasKey(dl => dl.Id)
            .HasName("pk_department_locations");

        builder.Property(dl => dl.Id)
            .HasConversion(
                id => id.Value,
                value => DepartmentLocationId.Create(value))
            .HasColumnName("id");

        builder.Property(dp => dp.DepartmentId)
            .HasColumnName("department_id");

        builder.HasOne<Department>()
            .WithMany(d => d.Locations) // без заполнения параметров создает две одинаковых колонки
            .HasForeignKey(dl => dl.DepartmentId)
            .HasConstraintName("fk_department_locations_department_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(dp => dp.LocationId)
            .HasColumnName("location_id");

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(dl => dl.LocationId)
            .HasConstraintName("fk_department_locations_location_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}