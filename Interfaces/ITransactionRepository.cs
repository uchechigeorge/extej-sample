using MVCWebApplication1.Data;
using MVCWebApplication1.Models;
using MVCWebApplication1.ViewModels;

namespace MVCWebApplication1.Interfaces;

public interface ITransactionRepository
{
  Task<ViewQuery<Transaction>> GetAll(GetTransactionsParametersViewModel paramters);
  Task<Transaction> GetById(string id);
  bool Add(Transaction user);
  bool Update(Transaction user);
  bool Delete(Transaction user);
  bool Save();
}