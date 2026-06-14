using MediatR;

namespace Szk3.Country.Application.Country.AddCountry;
public sealed record CreateCountryCommand(string Name, string Code, bool isActive = true ): IRequest<int>;

