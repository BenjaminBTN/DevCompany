using DevCompany.Domain.Departments;
using DevCompany.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCompany.Infrastructure.Configurations;

public class DepartmentPositionConfig : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");

        builder.HasKey(dl => dl.Id)
            .HasName("pk_department_positions");

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(dl => dl.DepartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Position>()
            .WithMany()
            .HasForeignKey(dl => dl.PositionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}