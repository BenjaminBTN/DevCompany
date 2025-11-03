using DevCompany.Domain.Departments;
using DevCompany.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCompany.Infrastructure.Configurations;

public class DepartmentLocationConfig : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");

        builder.HasKey(dl => dl.Id)
            .HasName("pk_department_locations");

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(dl => dl.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(dl => dl.LocationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}