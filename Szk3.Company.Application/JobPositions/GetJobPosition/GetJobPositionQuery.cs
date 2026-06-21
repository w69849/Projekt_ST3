using MediatR;
using Szk3.Company.Application.JobPositions.Models;

namespace Szk3.Company.Application.JobPositions.GetJobPosition
{
	public sealed record GetJobPositionQuery(int Id) : IRequest<JobPositionDetailsDto>;
}
