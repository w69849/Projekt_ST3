using MediatR;
using Szk3.Company.Domain.Enums;

namespace Szk3.Company.Application.JobPositions.AddRate
{
    public sealed record AddRateCommand(int JobPositionId, decimal Amount, string Currency, RateType RateType) : IRequest<int>
    {
    }
}
