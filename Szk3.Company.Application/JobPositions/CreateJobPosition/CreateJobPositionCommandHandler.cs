using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Application.JobPositions.CreateJobPosition
{
    public sealed class CreateJobPositionCommandHandler : IRequestHandler<CreateJobPositionCommand, int>
    {
        private readonly ICompanyContext _companyContext;

        public CreateJobPositionCommandHandler(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<int> Handle(CreateJobPositionCommand command, CancellationToken cancellationToken)
        {
            var name = command.Name?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidOperationException("Job position name cannot be empty.");
            }

            var exists = await _companyContext.JobPositions.AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);

            if (exists)
            {
                throw new InvalidOperationException($"Job position with name '{command.Name}' already exists.");
            }

            var jobPosition = new JobPosition(name, command.Code, command.IsActive);

            await _companyContext.JobPositions.AddAsync(jobPosition, cancellationToken);
            await _companyContext.SaveChangesAsync(cancellationToken);

            return jobPosition.Id;
        }
    }
}
