using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Infrastructure.Persistance.Configuration
{
	public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
	{
		public void Configure(EntityTypeBuilder<JobPosition> builder)
		{
			builder.ToTable(nameof(JobPosition));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.HasColumnName(nameof(JobPosition.Name))
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(x => x.Code)
				.HasColumnName(nameof(JobPosition.Code))
				.HasMaxLength(50);

			builder.Property(x => x.IsActive)
				.HasColumnName(nameof(JobPosition.IsActive))
				.IsRequired();

			builder.HasMany(x => x.Rates)
				.WithOne()
				.HasForeignKey("CompanyId")
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.Requirements)
				.WithOne()
				.HasForeignKey("CompanyId")
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			builder.Navigation(x => x.Rates).AutoInclude();
			builder.HasIndex(x => x.Rates).IsUnique();

			builder.Navigation(x => x.Requirements).AutoInclude();
			builder.HasIndex(x => x.Requirements).IsUnique();
		}
	}
}
