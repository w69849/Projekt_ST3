using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Szk3.Common.Infra;
using Szk3.Company.Domain.Entities.Company;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Infrastructure
{
	public class CompanyDbContext : PlatformDbContext, Application.Common.ICompanyContext
	{
		private readonly IConfiguration _configuration;

		public DbSet<Domain.Entities.Company.Company> Companies { get; set; } = null!;
		public DbSet<JobPosition> JobPositions { get; set; } = null!;

		public IQueryable<Domain.Entities.Company.Company> CompanyQuery => Set<Domain.Entities.Company.Company>().AsNoTracking().AsQueryable();
		public IQueryable<JobPosition> JobPositionQuery => Set<JobPosition>().AsNoTracking().AsQueryable();

		public CompanyDbContext(IConfiguration configuration, DbContextOptions<CompanyDbContext> options) : base(options)
		{
			_configuration = configuration;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(@"server=(localdb)\\MSSQLLocalDB;database=country-dev;trusted_connection=true;TrustServerCertificate=True;\", x => x.MigrationsHistoryTable("__EFMigrationsHistory", DbConst.SCHEMA_NAME));
		}
	}
}
