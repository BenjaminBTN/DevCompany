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

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .HasConversion(
                id => id.Value, 
                value => LocationId.Create(value))
            .HasColumnName("id");

        builder.ComplexProperty(l => l.Name, nb =>
        {
            nb.Property(l => l.Value)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_120)
                .HasColumnName("name");
        });

        builder.OwnsOne(l => l.Address, ab =>
        {
            ab.ToJson("address");

            ab.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.Region)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.HouseNumber)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_100);

            ab.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(Address.POSTAL_CODE_LENGTH);
        });

        builder.ComplexProperty(l => l.TimeZone, nb =>
        {
            nb.Property(l => l.Value)
                .IsRequired()
                .HasMaxLength(LengthConstants.LENGTH_100)
                .HasColumnName("time_zone");
        });

        builder.Property(l => l.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder.Property(d => d.CreatedAt)
            .IsRequired();

        builder.Property(d => d.UpdatedAt)
            .IsRequired();
    }
}