using Microsoft.Extensions.DependencyInjection;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddCompanyInfrastructure(this IServiceCollection services)
		{
			services.AddDbContext<CompanyDbContext>();
			services.AddScoped<ICompanyContext>(sp => sp.GetRequiredService<CompanyDbContext>());

			return services;
		}
	}
}
