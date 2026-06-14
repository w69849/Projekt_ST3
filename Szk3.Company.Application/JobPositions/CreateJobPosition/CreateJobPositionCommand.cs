using MediatR;

namespace Szk3.Company.Application.JobPositions.CreateJobPosition
{
    public sealed record CreateJobPositionCommand(string Name, string Code, bool IsActive) : IRequest<int>
    {}
}
