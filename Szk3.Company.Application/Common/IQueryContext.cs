using Szk3.Company.Domain.Entities.Company;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Application.Common
{
    public interface IQueryContext
    {
        IQueryable<Szk3.Company.Domain.Entities.Company.Company> CompanyQuery { get; }
        IQueryable<JobPosition> JobPositionQuery { get; }
    }
}
