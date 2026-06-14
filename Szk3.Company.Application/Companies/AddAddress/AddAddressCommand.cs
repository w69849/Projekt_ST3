using MediatR;

namespace Szk3.Company.Application.Companies.AddAddress
{
    public sealed record AddAddressCommand(int CompanyId,
            string Street,
            string BuildingNumber,
            string? ApartmentNumber,
            string PostalCode,
            string City,
            string Country,
            bool IsActive = true) : IRequest<int>
    {}
}
