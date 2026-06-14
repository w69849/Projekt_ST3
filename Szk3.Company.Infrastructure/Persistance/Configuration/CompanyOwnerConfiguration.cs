using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Szk3.Company.Domain.Entities.Company;

namespace Szk3.Company.Infrastructure.Persistance.Configuration
{
	public class CompanyOwnerConfiguration : IEntityTypeConfiguration<CompanyOwner>
	{
		public void Configure(EntityTypeBuilder<CompanyOwner> builder)
		{
			builder.ToTable(nameof(CompanyOwner));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.FullName)
				.HasColumnName(nameof(CompanyOwner.FullName))
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.PhoneNumber)
				.HasColumnName(nameof(CompanyOwner.PhoneNumber))
				.HasMaxLength(15);

			builder.Property(x => x.Email)
				.HasColumnName(nameof(CompanyOwner.Email))
				.HasMaxLength(50);
		}
	}
}
