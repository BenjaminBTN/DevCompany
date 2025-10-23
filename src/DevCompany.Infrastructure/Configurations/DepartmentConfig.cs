using DevCompany.Domain.Constants;
using DevCompany.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCompany.Infrastructure.Configurations;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(d => d.Id).HasName("Id");
        builder.Property(d => d.Name).IsRequired().HasMaxLength(LengthConstants.LENGTH_500);
    }
}