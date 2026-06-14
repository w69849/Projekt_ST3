using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Application.JobPositions.AddRequirement
{
    public sealed class AddRequirementCommandHandler : IRequestHandler<AddRequirementCommand, int>
    {
        private readonly ICompanyContext _companyContext;

        public AddRequirementCommandHandler(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<int> Handle(AddRequirementCommand command, CancellationToken cancellationToken)
        {
			var jobPosition = await _companyContext.JobPositions.FirstOrDefaultAsync(x => x.Id == command.JobPositionId, cancellationToken);

			if (jobPosition == null)
			{
				throw new InvalidOperationException($"JobPosition with id '{command.JobPositionId}' does not exist..");
			}

            var requirement = jobPosition.AddRequirement(command.Name, command.Description);
            await _companyContext.SaveChangesAsync(cancellationToken);

            return requirement.Id;
		}
    }
}
