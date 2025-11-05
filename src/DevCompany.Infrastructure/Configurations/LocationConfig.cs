using DevCompany.Domain.Constants;
using DevCompany.Domain.Locations;
using DevCompany.Domain.Locations.VO;
using DevCompany.Domain.Shared.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCompany.Infrastructure.Configurations;

public class LocationConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");

        builder.HasKey(l => l.Id)
            .HasName("pk_locations");

        builder.Property(l => l.Id)
            .HasConversion(
                id => id.Value, 
                value => LocationId.Create(value))
            .HasColumnName("id");

        builder.ComplexProperty(l => l.Name, nb =>
        {
            nb.Property(l => l.Value)
                .HasMaxLength(LengthConstants.LENGTH_120)
                .HasColumnName("name");
        });

        builder.OwnsOne(l => l.Address, ab =>
        {
            ab.ToJson("address");

            ab.Property(a => a.Country)
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.Region)
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.City)
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.Street)
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.HouseNumber)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.PostalCode)
                .HasMaxLength(Address.POSTAL_CODE_LENGTH);
        });

        builder.ComplexProperty(l => l.TimeZone, nb =>
        {
            nb.Property(l => l.Value)
                .HasMaxLength(LengthConstants.LENGTH_100)
                .HasColumnName("time_zone");
        });

        builder.Property(l => l.IsActive)
            .HasColumnName("is_active");

        builder.Property(l => l.CreatedAt)
            .HasColumnName("crated_at");

        builder.Property(l => l.UpdatedAt)
            .HasColumnName("updated_at");
    }
}