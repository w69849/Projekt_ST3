namespace Szk3.Company.Application.JobPositions.Models
{
	public sealed class PositionRateDto
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public string RateType { get; set; }
	}
}
