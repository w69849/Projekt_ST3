
using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Application.Companies.CreateCompany
{
    public sealed class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly ICompanyContext _companyContext;

        public CreateCompanyCommandHandler(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<int> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            var existingCompany = await _companyContext.Companies.AnyAsync(x => x.NIP == command.NIP);

            if (existingCompany)
            {
                throw new InvalidOperationException($"Country with NIP '{command.NIP}' already exists.");
            }

            var company = new Domain.Entities.Company.Company();
            company.UpdateCompanyData(command.Name, command.ShortName, command.REGON, command.NIP, command.KRAZ, command.KRS);

            _companyContext.Add(company);
            await _companyContext.SaveChangesAsync(cancellationToken);

            return company.Id;
        }
    }
}