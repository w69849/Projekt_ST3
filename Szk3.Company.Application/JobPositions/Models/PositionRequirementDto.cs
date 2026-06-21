namespace Szk3.Company.Application.JobPositions.Models
{
	public sealed class PositionRequirementDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}
