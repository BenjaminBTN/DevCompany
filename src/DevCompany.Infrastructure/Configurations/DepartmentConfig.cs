using DevCompany.Domain.Constants;
using DevCompany.Domain.Departments;
using DevCompany.Domain.Departments.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCompany.Infrastructure.Configurations;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(d => d.Id).HasName("pk_departments");

        builder.Property(d => d.Id)
            .HasConversion(
                id => id.Value, 
                value => DepartmentId.Create(value))
            .HasColumnName("id");

        builder.ComplexProperty(d => d.Name, nb => 
        { 
            nb.Property(d => d.Value)
            .IsRequired()
            .HasMaxLength(LengthConstants.LENGTH_150)
            .HasColumnName("name");
        });

        builder.Property(d => d.Identifier)
            .IsRequired()
            .HasMaxLength(LengthConstants.LENGTH_150)
            .HasColumnName("identifier");

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(d => d.ParentId)
            .IsRequired(false);

        builder.ComplexProperty(d => d.Path, nb =>
        {
            nb.Property(d => d.Value)
            .IsRequired()
            .HasMaxLength(LengthConstants.LENGTH_150)
            .HasColumnName("path");
        });

        builder.Property(d => d.Depth)
            .IsRequired()
            .HasMaxLength(LengthConstants.LENGTH_100)
            .HasColumnName("depth");

        builder.Property(d => d.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder.Property(d => d.CreatedAt)
            .IsRequired();

        builder.Property(d => d.UpdatedAt)
            .IsRequired();

        builder.HasMany(d => d.DepartmentLocations)
            .WithOne()
            .IsRequired()
            .HasForeignKey(dl => dl.DepartmentId);

        builder.HasMany(d => d.DepartmentPositions)
            .WithOne()
            .IsRequired()
            .HasForeignKey(dp => dp.DepartmentId);
    }
}