using MediatR;

namespace Szk3.Company.Application.JobPositions.DeleteRate
{
    public sealed record DeleteRateCommand(int JobPositionId, int RateId) : IRequest;
}
