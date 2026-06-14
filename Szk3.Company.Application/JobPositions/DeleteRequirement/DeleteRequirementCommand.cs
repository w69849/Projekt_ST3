using MediatR;

namespace Szk3.Company.Application.JobPositions.DeleteRequirement
{
    public sealed record DeleteRequirementCommand(int JobPositionId, int RequirementId) : IRequest;
}
