using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Szk3.Company.Domain.Entities.Company;

namespace Szk3.Company.Infrastructure.Persistance.Configuration
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Entities.Company>
	{
		public void Configure(EntityTypeBuilder<Entities.Company> builder)
		{
			builder.ToTable(nameof(Entities.Company));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.HasColumnName(nameof(Entities.Company.Name))
				.IsRequired()
				.HasMaxLength(200);
			builder.Property(x => x.ShortName)
				.HasColumnName(nameof(Entities.Company.ShortName))
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(x => x.NIP)
				.HasColumnName(nameof(Entities.Company.NIP))
				.HasMaxLength(50);
			builder.Property(x => x.REGON)
				.HasColumnName(nameof(Entities.Company.REGON))
				.HasMaxLength(50);
			builder.Property(x => x.KRAZ)
				.HasColumnName(nameof(Entities.Company.KRAZ))
				.HasMaxLength(50);
			builder.Property(x => x.KRS)
				.HasColumnName(nameof(Entities.Company.KRS))
				.HasMaxLength(100);

			builder.HasMany(x => x.Addresses)
				.WithOne()
				.HasForeignKey("CompanyId")
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.Owners)
				.WithOne()
				.HasForeignKey("CompanyId")
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			builder.Navigation(x => x.Addresses).AutoInclude();
			builder.HasIndex(x => x.Addresses).IsUnique();

			builder.Navigation(x => x.Owners).AutoInclude();
			builder.HasIndex(x => x.Owners).IsUnique();
		}
	}
}
