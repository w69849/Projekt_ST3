using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Szk3.Country.Domain.Entities.Countries;

namespace Szk3.Country.Infra.Persistanc.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName(nameof(City.Name)).IsRequired().HasMaxLength(200); 
            builder.Property(x => x.IsActive).HasColumnName(nameof(City.IsActive)).IsRequired();
        }
    }
}
