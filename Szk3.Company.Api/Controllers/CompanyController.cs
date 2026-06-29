using MediatR;
using Microsoft.AspNetCore.Mvc;
using Szk3.Company.Application.Companies.AddAddress;
using Szk3.Company.Application.Companies.AddOwner;
using Szk3.Company.Application.Companies.CreateCompany;

namespace Szk3.Company.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CompanyController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CompanyController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("address")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
		public async Task<IActionResult> AddAddress([FromBody] AddAddressCommand request, CancellationToken token)
		{
			var addressId = await _mediator.Send(request, token);

			return Ok(addressId);
		}

		[HttpPost("owner")]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
		public async Task<IActionResult> AddOwner([FromBody] AddOwnerCommand request, CancellationToken token)
		{
			var ownerId = await _mediator.Send(request, token);

			return Ok(ownerId);
		}

		[HttpPost]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyCommand request, CancellationToken token)
		{
			var companyId = await _mediator.Send(request, token);
			return Ok(companyId);
		}
	}
}
