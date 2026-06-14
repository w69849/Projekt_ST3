using MediatR;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.GetCountries
{
    public sealed record GetCountriesQuery(): IRequest<List<CountryDto>>;
    
}
