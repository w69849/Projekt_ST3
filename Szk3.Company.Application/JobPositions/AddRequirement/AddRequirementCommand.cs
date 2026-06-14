using MediatR;

namespace Szk3.Company.Application.JobPositions.AddRequirement
{
    public sealed record AddRequirementCommand(int JobPositionId, string Name, string? Description) : IRequest<int>
    {}
}
