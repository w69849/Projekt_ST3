using MediatR;
using Microsoft.AspNetCore.Mvc;
using Szk3.Company.Application.JobPositions.AddRate;
using Szk3.Company.Application.JobPositions.AddRequirement;
using Szk3.Company.Application.JobPositions.CreateJobPosition;
using Szk3.Company.Application.JobPositions.DeleteRate;
using Szk3.Company.Application.JobPositions.DeleteRequirement;
using Szk3.Company.Application.JobPositions.GetJobPosition;
using Szk3.Company.Application.JobPositions.Models;

namespace Szk3.Company.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class JobPositionController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JobPositionController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(JobPositionDetailsDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new GetJobPositionQuery(id), cancellationToken);
			if (result is null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost("{jobPositionId:int}/rates")]
		[ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
		public async Task<IActionResult> AddRate([FromRoute] int jobPositionId, [FromBody] AddRateCommand request, CancellationToken cancellationToken)
		{
			var rateId = await _mediator.Send(request with { JobPositionId = jobPositionId }, cancellationToken);
			return CreatedAtAction(nameof(GetById), new { id = jobPositionId }, rateId);
		}

		[HttpPost("{jobPositionId:int}/requirements")]
		[ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
		public async Task<IActionResult> AddRequirement([FromRoute] int jobPositionId, [FromBody] AddRequirementCommand request, CancellationToken cancellationToken)
		{
			var requirementId = await _mediator.Send(request with { JobPositionId = jobPositionId }, cancellationToken);
			return CreatedAtAction(nameof(GetById), new { id = jobPositionId }, requirementId);
		}

		[HttpDelete("{jobPositionId:int}/rates/{rateId:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteRate([FromRoute] int jobPositionId, [FromRoute] int rateId, CancellationToken cancellationToken)
		{
			await _mediator.Send(new DeleteRateCommand(jobPositionId, rateId), cancellationToken);
			return NoContent();
		}

		[HttpDelete("{jobPositionId:int}/requirements/{requirementId:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteRequirement([FromRoute] int jobPositionId, [FromRoute] int requirementId, CancellationToken cancellationToken)
		{
			await _mediator.Send(new DeleteRequirementCommand(jobPositionId, requirementId), cancellationToken);
			return NoContent();
		}

		[HttpPost]
		[ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
		public async Task<IActionResult> CreateJobPosition([FromBody] CreateJobPositionCommand request, CancellationToken cancellationToken)
		{
			var jobPositionId = await _mediator.Send(request, cancellationToken);

			return CreatedAtAction(nameof(GetById), new { id = jobPositionId }, jobPositionId);
		}
	}
}
