using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Application.JobPositions.AddRate
{
    public sealed class AddRateCommandHandler : IRequestHandler<AddRateCommand, int>
    {
        private readonly ICompanyContext _companyContext;

        public AddRateCommandHandler(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<int> Handle(AddRateCommand command, CancellationToken cancellationToken)
        {
            var jobPosition = await _companyContext.JobPositions.FirstOrDefaultAsync(x => x.Id == command.JobPositionId, cancellationToken);

            if (jobPosition == null)
            {
                throw new InvalidOperationException($"JobPosition with id '{command.JobPositionId}' does not exist..");
            }

            var rate = jobPosition.AddRate(command.Amount, command.Currency, command.RateType);
            await _companyContext.SaveChangesAsync(cancellationToken);

            return rate.Id;
        }
    }
}
