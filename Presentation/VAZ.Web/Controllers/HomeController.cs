using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VAZ.Application.Catalog.Products.Commands.Models;
using VAZ.Application.Catalog.Products.Queries.Models;
using VAZ.Web.Framework.Controllers;
using VAZ.Web.Models;

namespace VAZ.Web.Controllers
{
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateProductCommand createProductCommand)
		{
			await Mediator.Send(createProductCommand);

			return Content("ok");
		}

		public async Task<IActionResult> GetAll()
		{
			
			return Content((await Mediator.Send(new GetProductsQuery())).Data.FirstOrDefault().Pictures.FirstOrDefault().FileSize.ToString());
		}

		[HttpGet("delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await Mediator.Send(new DeleteProductCommand { Id = id }));
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}