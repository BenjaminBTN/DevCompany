using DevCompany.Domain.Departments;
using DevCompany.Domain.Departments.VO;
using DevCompany.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCompany.Infrastructure.Configurations;

public class DepartmentPositionConfig : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");

        builder.HasKey(dp => dp.Id)
            .HasName("pk_department_positions");

        builder.Property(dp => dp.Id)
            .HasConversion(
                id => id.Value,
                value => DepartmentPositionId.Create(value))
            .HasColumnName("id");

        builder.Property(dp => dp.DepartmentId)
            .HasColumnName("department_id");

        builder.HasOne<Department>()
            .WithMany(d => d.Positions) // без заполнения параметров создает две одинаковых колонки
            .HasForeignKey(dp => dp.DepartmentId)
            .HasConstraintName("fk_department_positions_department_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(dp => dp.PositionId)
            .HasColumnName("position_id");

        builder.HasOne<Position>()
            .WithMany()
            .HasForeignKey(dp => dp.PositionId)
            .HasConstraintName("fk_department_positions_position_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}