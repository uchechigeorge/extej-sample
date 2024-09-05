using System.ComponentModel.DataAnnotations;
using MVCApplication1.Attributes;
using MVCWebApplication1.Data.Enums;

namespace MVCWebApplication1.ViewModels;

public class AddTransactionViewModel
{
  [Required]
  public string? Description { get; set; }
  [Required]
  public string? Reference { get; set; }
  [Required]
  [PositiveNonZero]
  public decimal? Amount { get; set; }
  [Required]
  [PositiveNonZero]
  public decimal? Value { get; set; }
  [Required]
  [PositiveNonZero]
  public int? Type { get; set; }
  [Required]
  public TransactionStatus StatusId { get; set; }
  [Required]
  public DateTime? TransactionDate { get; set; }
}