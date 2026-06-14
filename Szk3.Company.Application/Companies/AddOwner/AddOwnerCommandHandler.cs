using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Domain.Entities.Company;

namespace Szk3.Company.Application.Companies.AddOwner
{
    public sealed class AddOwnerCommandHandler : IRequestHandler<AddOwnerCommand, int>
    {
        private readonly ICompanyContext _companyContext;

        public AddOwnerCommandHandler(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<int> Handle(AddOwnerCommand command, CancellationToken cancellationToken)
        {
            var company = await _companyContext.Companies.FirstOrDefaultAsync(x => x.Id == command.CompanyId);

            if (company == null)
            {
                throw new InvalidOperationException($"Country with id '{command.CompanyId}' does not exist..");
            }

            var ownerExists = company.Owners.Any(x => x.FullName.ToLower() == command.FullName.ToLower());

            if (ownerExists)
            {
                throw new InvalidOperationException($"City with name '{command.FullName}' already exists in country '{command.FullName}'");
            }

            var owner = new CompanyOwner(command.FullName, command.PhoneNumber, command.Email);
            company.AddOwner(owner);
            await _companyContext.SaveChangesAsync(cancellationToken);
            var addedOwner = company.Owners.Last();

            return addedOwner.Id;
        }
    }
}
