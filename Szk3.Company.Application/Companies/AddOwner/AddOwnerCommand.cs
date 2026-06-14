using MediatR;

namespace Szk3.Company.Application.Companies.AddOwner
{
    public sealed record AddOwnerCommand(int CompanyId, string FullName, string PhoneNumber, string Email) : IRequest<int>
    {
    }
}
