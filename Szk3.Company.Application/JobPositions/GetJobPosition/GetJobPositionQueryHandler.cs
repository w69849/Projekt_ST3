using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Application.JobPositions.Models;

namespace Szk3.Company.Application.JobPositions.GetJobPosition
{
	public sealed class GetJobPositionQueryHandler : IRequestHandler<GetJobPositionQuery, List<JobPositionDto>>
	{
		private readonly ICompanyContext _companyContext;

		public GetJobPositionQueryHandler(ICompanyContext companyContext)
		{
			_companyContext = companyContext;
		}

		public async Task<List<JobPositionDto>> Handle(GetJobPositionQuery request, CancellationToken cancellationToken)
		{
			var countries = await _companyContext.JobPositions.Select(
				x => new JobPositionDto
				{
					Id = x.Id,
					Name = x.Name,
				}).ToListAsync(cancellationToken);

			return countries;
		}
	}
}
