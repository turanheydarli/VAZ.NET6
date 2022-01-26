using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VAZ.Application.Catalog.Engines.Commands.Models;
using VAZ.Application.Catalog.Engines.Queries.Models;
using VAZ.Application.Interfaces;
using VAZ.Web.Framework.Controllers;
using WEB.Models;

namespace WEB.Controllers
{
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, IProductService productService)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return Ok(await Mediator.Send(new GetEnginesQuery()));
		}

		[HttpGet("add")]
		public async Task<IActionResult> Add()
		{
			return Ok(await Mediator.Send(new CreateEngineCommand { Name = "test" }));
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