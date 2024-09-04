using Microsoft.AspNetCore.Mvc;
using MVCWebApplication1.Helpers;
using MVCWebApplication1.Interfaces;
using MVCWebApplication1.Models;
using MVCWebApplication1.ViewModels;
using System.Diagnostics;

namespace MVCWebApplication1.Controllers
{
	public class HomeController(ITransactionRepository transactionRepository) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index(GetTransactionsParametersViewModel parameters)
		{
			var result = await transactionRepository.GetAll(parameters);
			var data = result.Data;
			var totalRows = result.TotalRows;

			var response = new GetTransactionsResBodyViewModel
			{
				Data = data,
				Message = "Ok",
				Status = 200,
				Page = parameters.Page,
				PageSize = parameters.PageSize,
				Year = parameters.Year,
				StatusId = parameters.StatusId,
				TotalRows = totalRows,
				TotalPages = (int)Math.Ceiling(totalRows / (double)parameters.PageSize),
				EndDate = parameters.EndDate,
				StartDate = parameters.StartDate,
				CurrentBalance = result.Extras?.GetValueOrDefault("CurrentBalance").GetDecimal().ToString("N2"),
				SortColumn = parameters.SortColumn,
				SortDirection = parameters.SortDirection,
			};

			return View(response);
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
