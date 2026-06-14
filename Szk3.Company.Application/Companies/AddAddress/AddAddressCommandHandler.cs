

using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Domain.Entities.Company;

namespace Szk3.Company.Application.Companies.AddAddress
{
    public sealed class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, int>
    {
        private readonly ICompanyContext _companyContext;

        public AddAddressCommandHandler(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        public async Task<int> Handle(AddAddressCommand command, CancellationToken cancellationToken)
        {
            var company = await _companyContext.Companies.FirstOrDefaultAsync(x => x.Id == command.CompanyId);

            if (company == null)
            {
                throw new InvalidOperationException($"Country with id '{command.CompanyId}' does not exist..");
            }

            var address = new CompanyAddress
                (command.Street, command.BuildingNumber, command.ApartmentNumber, command.PostalCode, command.City, command.Country, command.IsActive);

            company.AddAddress(address);
            await _companyContext.SaveChangesAsync(cancellationToken);
            var addedAddress = company.Addresses.Last();

            return addedAddress.Id;
        }
    }
}
