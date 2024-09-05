using MVCWebApplication1.Data.Enums;

namespace MVCWebApplication1.ViewModels;

public class AddTransactionViewModel
{
  public string? Description { get; set; }
  public string? Reference { get; set; }
  public decimal? Amount { get; set; }
  public decimal? Value { get; set; }
  public int? Type { get; set; }
  public TransactionStatus StatusId { get; set; }
  public DateTime? TransactionDate { get; set; }
}