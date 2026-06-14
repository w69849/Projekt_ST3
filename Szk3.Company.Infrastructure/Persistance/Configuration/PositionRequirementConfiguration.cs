using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Infrastructure.Persistance.Configuration
{
	public class PositionRequirementConfiguration : IEntityTypeConfiguration<PositionRequirement>
	{
		public void Configure(EntityTypeBuilder<PositionRequirement> builder)
		{
			builder.ToTable(nameof(PositionRequirement));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.HasColumnName(nameof(PositionRequirement.Name))
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Description)
				.HasColumnName(nameof(PositionRequirement.Description))
				.HasMaxLength(200);
		}
	}
}
