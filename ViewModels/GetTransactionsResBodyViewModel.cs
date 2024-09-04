using MVCWebApplication1.Data.Enums;
using MVCWebApplication1.Models;

namespace MVCWebApplication1.ViewModels;

public class GetTransactionsResBodyViewModel : GetResBodyViewModel<Transaction>
{
  public string? CurrentBalance { get; set; }
  public int? Year { get; set; }
  public TransactionStatus? StatusId { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}
