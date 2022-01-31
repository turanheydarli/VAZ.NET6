using Microsoft.AspNetCore.Mvc;
using VAZ.Application.Catalog.Cities.Commands.Models;
using VAZ.Application.Catalog.Cities.Queries.Models;
using WebAPI.Controllers;

namespace VAZ.WebAPI.Controllers.v1
{
	[Route("api/v1/[controller]")]
	public class CitiesController : BaseApiController
	{

		[HttpGet]
		public async Task<IActionResult> GetAllCities()
		{
			return GetResponse(await Mediator.Send(new GetCitiesQuery()));
		}

		[HttpPost]
		public async Task<IActionResult> AddCity([FromForm] CreateCityCommand createCityCommand)
		{
			return GetResponse(await Mediator.Send(createCityCommand));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCity([FromRoute] int id)
		{
			return GetResponseOnlyResult(await Mediator.Send(new DeleteCityCommand { Id = id }));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCity([FromForm] UpdateCityCommand updateCityCommand)
		{
			return GetResponse(await Mediator.Send(updateCityCommand));
		}
	}
}
