using MVCWebApplication1.ViewModels;

namespace MVCWebApplication1.Interfaces;

public interface ITransactionService
{
  Task<GetTransactionsResBodyViewModel> GetAllAndMapResponseAsync(GetTransactionsParametersViewModel paramters);
  Task<bool> AddAsync(AddTransactionViewModel model);
}