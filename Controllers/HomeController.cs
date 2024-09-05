using Microsoft.AspNetCore.Mvc;
using MVCWebApplication1.Interfaces;
using MVCWebApplication1.Models;
using MVCWebApplication1.ViewModels;
using System.Diagnostics;

namespace MVCWebApplication1.Controllers
{
	public class HomeController(ITransactionService transactionService, ITransactionRepository transactionRepository) : Controller
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
			if (!ModelState.IsValid)
			{
				var transaction = new Transaction
				{
					Amount = model.Amount,
					Description = model.Description,
					Reference = model.Reference,
					StatusId = model.StatusId,
					TransactionDate = model.TransactionDate,
					Type = model.Type,
					Value = model.Value,
				};
				await transactionRepository.Add(transaction);

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
