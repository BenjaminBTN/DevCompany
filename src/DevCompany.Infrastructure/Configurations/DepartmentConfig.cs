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

        builder.HasKey(d => d.Id)
            .HasName("pk_departments");

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

        builder.Property(d => d.ParentId)
            .HasConversion(
                id => id!.Value,
                value => DepartmentId.Create(value))
            .IsRequired(false)
            .HasColumnName("parent_id");

        builder.HasOne(d => d.Parent)
            .WithMany(d => d.Childrens)
            .HasForeignKey(d => d.ParentId)
            .HasConstraintName("fk_departments_parent_id")
            .OnDelete(DeleteBehavior.Cascade);

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
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(d => d.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
    }
}