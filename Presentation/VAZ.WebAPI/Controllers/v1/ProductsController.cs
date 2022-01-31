using WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using VAZ.Application.Catalog.Products.Commands.Models;
using VAZ.Application.Catalog.Products.Queries.Models;
using VAZ.Application.Catalog.Cities.Commands.Models;

namespace VAZ.WebAPI.Controllers.v1
{
	[Route("api/v1/[controller]")]
	public class ProductsController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			return GetResponse(await Mediator.Send(new GetProductsQuery()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			return GetResponse(await Mediator.Send(new GetProductQuery { Id = id}));
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct([FromForm] CreateProductCommand createProductCommand)
		{
			return GetResponse(await Mediator.Send(createProductCommand));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct([FromRoute] int id)
		{
			return GetResponseOnlyResult(await Mediator.Send(new DeleteProductCommand { Id = id }));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommand updateProductCommand)
		{
			return GetResponse(await Mediator.Send(updateProductCommand));
		}
	}
}
