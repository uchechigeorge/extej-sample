using MVCWebApplication1.Helpers;
using MVCWebApplication1.Interfaces;
using MVCWebApplication1.Models;
using MVCWebApplication1.ViewModels;

namespace MVCWebApplication1.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
  public async Task<GetTransactionsResBodyViewModel> GetAllAndMapResponseAsync(GetTransactionsParametersViewModel parameters)
  {
    var result = await transactionRepository.GetAll(parameters);

    var response = new GetTransactionsResBodyViewModel
    {
      Data = result.Data,
      Message = "Ok",
      Status = 200,
      Page = parameters.Page,
      PageSize = parameters.PageSize,
      Year = parameters.Year,
      StatusId = parameters.StatusId,
      TotalRows = result.TotalRows,
      TotalPages = (int)Math.Ceiling(result.TotalRows / (double)parameters.PageSize),
      EndDate = parameters.EndDate,
      StartDate = parameters.StartDate,
      CurrentBalance = result.Extras?.GetValueOrDefault("CurrentBalance").GetDecimal().ToString("N2"),
      SortColumn = parameters.SortColumn,
      SortDirection = parameters.SortDirection,
    };

    return response;
  }

  public async Task<bool> AddAsync(AddTransactionViewModel model)
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
    return await transactionRepository.Add(transaction);
  }
}