using MVCWebApplication1.Data.Enums;

namespace MVCWebApplication1.ViewModels;

public class GetTransactionsParametersViewModel : GetReqParametersViewModel
{
  public TransactionStatus? StatusId { get; set; }
  public int? Year { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}