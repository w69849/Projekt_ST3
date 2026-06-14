using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Application.JobPositions.DeleteRequirement
{
    public sealed class DeleteRequirementCommandHandler : IRequestHandler<DeleteRequirementCommand>
    {
        private readonly ICompanyContext _companyContext;

        public DeleteRequirementCommandHandler(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task Handle(DeleteRequirementCommand command, CancellationToken cancellationToken)
        {
            var jobPosition = await _companyContext.JobPositions.FirstOrDefaultAsync(x => x.Id == command.JobPositionId, cancellationToken);

            if (jobPosition == null)
            {
                throw new InvalidOperationException($"Job position with id '{command.JobPositionId}' does not exist.");
            }

            jobPosition.DeleteRequirement(command.RequirementId);

            await _companyContext.SaveChangesAsync(cancellationToken);
        }
    }
}
