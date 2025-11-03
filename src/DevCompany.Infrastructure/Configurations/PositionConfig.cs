using DevCompany.Domain.Constants;
using DevCompany.Domain.Positions;
using DevCompany.Domain.Positions.VO;
using DevCompany.Domain.Shared.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCompany.Infrastructure.Configurations;

public class PositionConfig : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PositionId.Create(value))
            .HasColumnName("id");

        builder.ComplexProperty(p => p.Name, nb =>
        {
            nb.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_100)
                .HasColumnName("name");
        });

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(LengthConstants.LENGTH_1000)
            .HasColumnName("description");

        builder.Property(p => p.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .IsRequired();
    }
}