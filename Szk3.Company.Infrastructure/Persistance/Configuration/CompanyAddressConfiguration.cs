using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Szk3.Company.Domain.Entities.Company;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Infrastructure.Persistance.Configuration
{
	public class CompanyAddressConfiguration : IEntityTypeConfiguration<CompanyAddress>
	{
		public void Configure(EntityTypeBuilder<CompanyAddress> builder)
		{
			builder.ToTable(nameof(CompanyAddress));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Street)
				.HasColumnName(nameof(CompanyAddress.Street))
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.BuildingNumber)
				.HasColumnName(nameof(CompanyAddress.BuildingNumber))
				.IsRequired()
				.HasMaxLength(5);

			builder.Property(x => x.ApartmentNumber)
				.HasColumnName(nameof(CompanyAddress.ApartmentNumber))
				.HasMaxLength(5);

			builder.Property(x => x.PostalCode)
				.HasColumnName(nameof(CompanyAddress.PostalCode))
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.City)
				.HasColumnName(nameof(CompanyAddress.City))
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Country)
				.HasColumnName(nameof(CompanyAddress.Country))
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.IsActive)
				.HasColumnName(nameof(CompanyAddress.IsActive))
				.IsRequired();
		}
	}
}
