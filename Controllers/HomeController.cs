using Microsoft.AspNetCore.Mvc;
using MVCWebApplication1.Interfaces;
using MVCWebApplication1.Models;
using MVCWebApplication1.ViewModels;
using System.Diagnostics;

namespace MVCWebApplication1.Controllers
{
	public class HomeController(ITransactionService transactionService) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index(GetTransactionsParametersViewModel parameters)
		{
			var response = await transactionService.GetAllAndMapResponseAsync(parameters);

			return View(response);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddTransactionViewModel model)
		{
			if (ModelState.IsValid)
			{
				await transactionService.AddAsync(model);
				return RedirectToAction("Index");
			}

			return View(model);
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
