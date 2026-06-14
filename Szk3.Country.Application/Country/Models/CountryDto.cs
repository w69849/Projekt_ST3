namespace Szk3.Country.Application.Country.Models
{
    public class CountryDto
    {
        public int Id { get; set; }
        public required string Name { get; init; }
        public required string Code { get; init; }
        public bool IsActive { get; set; }
    }
}
