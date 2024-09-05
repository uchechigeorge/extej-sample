using MVCWebApplication1.Data;
using MVCWebApplication1.Models;
using MVCWebApplication1.ViewModels;

namespace MVCWebApplication1.Interfaces;

public interface ITransactionRepository
{
  Task<ViewQuery<Transaction>> GetAll(GetTransactionsParametersViewModel paramters);
  Task<Transaction> GetById(string id);
  Task<bool> Add(Transaction transaction);
  Task<bool> Update(Transaction transaction);
  Task<bool> Delete(Transaction transaction);
  Task<bool> Save();
}