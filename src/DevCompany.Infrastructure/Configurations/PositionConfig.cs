using DevCompany.Domain.Constants;
using DevCompany.Domain.Positions;
using DevCompany.Domain.Positions.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCompany.Infrastructure.Configurations;

public class PositionConfig : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");

        builder.HasKey(p => p.Id)
            .HasName("pk_positions");

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PositionId.Create(value))
            .HasColumnName("id");

        builder.ComplexProperty(p => p.Name, nb =>
        {
            nb.Property(p => p.Value)
                .HasMaxLength(LengthConstants.LENGTH_100)
                .HasColumnName("name");
        });

        builder.Property(p => p.Description)
            .IsRequired(false)
            .HasMaxLength(LengthConstants.LENGTH_1000)
            .HasColumnName("description");

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active");

        builder.Property(p => p.CreatedAt)
            .HasColumnName("crated_at");

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at");
    }
}