using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Application.JobPositions.Models;

namespace Szk3.Company.Application.JobPositions.GetJobPosition
{
	public sealed class GetJobPositionQueryHandler : IRequestHandler<GetJobPositionQuery, JobPositionDetailsDto>
	{
		private readonly ICompanyContext _companyContext;

		public GetJobPositionQueryHandler(ICompanyContext companyContext)
		{
			_companyContext = companyContext;
		}

		public async Task<JobPositionDetailsDto?> Handle(GetJobPositionQuery request, CancellationToken cancellationToken)
		{
			var jobPosition = await _companyContext.JobPositions
				.Where(x => x.Id == request.Id)
				.Select(x => new JobPositionDetailsDto
				{
					Id = x.Id,
					Name = x.Name,
					Code = x.Code,
					IsActive = x.IsActive,
					Rates = x.Rates.Select(r => new PositionRateDto
					{
						Id = r.Id,
						Amount = r.Amount,
						Currency = r.Currency
					}).ToList(),
					Requirements = x.Requirements.Select(r => new PositionRequirementDto
					{
						Id = r.Id,
						Name = r.Name,
						Description = r.Description
					}).ToList()
				}).FirstOrDefaultAsync(cancellationToken);

			return jobPosition;
		}
	}
}
