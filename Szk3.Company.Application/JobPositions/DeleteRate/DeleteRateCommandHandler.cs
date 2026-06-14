using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Application.JobPositions.DeleteRate
{
    public sealed class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand>
    {
        private readonly ICompanyContext _companyContext;

        public DeleteRateCommandHandler(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task Handle(DeleteRateCommand command, CancellationToken cancellationToken)
        {
            var jobPosition = await _companyContext.JobPositions.FirstOrDefaultAsync(x => x.Id == command.JobPositionId, cancellationToken);

            if (jobPosition == null)
            {
                throw new InvalidOperationException($"Job position with id '{command.JobPositionId}' does not exist.");
            }

            jobPosition.DeleteRate(command.RateId);

            await _companyContext.SaveChangesAsync(cancellationToken);
        }
    }
}
