using Microsoft.EntityFrameworkCore;
using MVCWebApplication1.Data;
using MVCWebApplication1.Helpers;
using MVCWebApplication1.Interfaces;
using MVCWebApplication1.Models;
using MVCWebApplication1.ViewModels;

namespace MVCWebApplication1.Repositories;

public class TransactionRepository(ApplicationDbContext dbContext) : ITransactionRepository
{
  public async Task<ViewQuery<Transaction>> GetAll(GetTransactionsParametersViewModel parameters)
  {
    var sortOptions = new Dictionary<string, string>
      {
        { "Description", "" },
        { "Amount", "" },
        { "Type", "" },
        { "Value", "" },
        { "TransactionDate", "" },
      };
    var query = dbContext.Transactions.AsQueryable();

    if (parameters.Year != null)
    {
      query = query.Where(e => e.TransactionDate!.Value.Year == parameters.Year);
    }

    if (parameters.StatusId != null)
    {
      query = query.Where(e => e.StatusId == parameters.StatusId);
    }

    //if (parameters.StartDate != null)
    //{
    //  query = query.Where(e => e.TransactionDate >= parameters.StartDate);
    //}

    //if (parameters.EndDate != null)
    //{
    //  query = query.Where(e => e.TransactionDate <= parameters.EndDate);
    //}

    int totalRows = await query.CountAsync();

    var sortColumn = ViewHelpers.GetSortColumn(parameters.SortColumn, sortOptions, "TransactionDate");
    var isDescending = ViewHelpers.IsDescendingOrder(parameters.SortDirection);
    query = query.OrderBy(sortColumn, isDescending);
    query = query.Skip(parameters.PageSize.GetNaturalInt() * (parameters.Page.GetNaturalInt() - 1)).Take(parameters.PageSize.GetNaturalInt());

    var currentBalance = await query.SumAsync(e => e.Value);
    var data = await query.ToListAsync();

    var result = new ViewQuery<Transaction>
    {
      Query = query,
      Data = data,
      TotalRows = totalRows,
      SortColumn = sortColumn,
      IsDescending = isDescending,
      Extras = new Dictionary<string, object>
      {
          { "CurrentBalance", currentBalance },
      },
    };

    return result;
  }

  public Task<Transaction> GetById(string id)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Add(Transaction transaction)
  {
    await dbContext.AddAsync(transaction);
    return await Save();
  }

  public Task<bool> Delete(Transaction transaction)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Save()
  {
    var saved = await dbContext.SaveChangesAsync();
    return saved > 0;
  }

  public Task<bool> Update(Transaction transaction)
  {
    throw new NotImplementedException();
  }
}