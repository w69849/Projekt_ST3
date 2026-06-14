using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Szk3.Company.Domain.Entities.Company;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Infrastructure.Persistance.Configuration
{
	public class PositionRateConfiguration : IEntityTypeConfiguration<PositionRate>
	{
		public void Configure(EntityTypeBuilder<PositionRate> builder)
		{
			builder.ToTable(nameof(PositionRate));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Amount)
				.HasColumnName(nameof(PositionRate.Amount))
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Currency)
				.HasColumnName(nameof(PositionRate.Currency))
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(x => x.RateType)
				.HasColumnName(nameof(PositionRate.RateType))
				.IsRequired()
				.HasMaxLength(50);
		}
	}
}
