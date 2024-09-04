using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCWebApplication1.Data.Enums;

namespace MVCWebApplication1.Models;

#region Table

public class Transaction
{
  [Key]
  public int Id { get; set; }

  public string? Description { get; set; }

  [StringLength(1024)]
  public string? Reference { get; set; }

  [Column("Amount", TypeName = "decimal(18, 2)")]
  public decimal? Amount { get; set; }

  [Column("Value", TypeName = "decimal(18, 2)")]
  public decimal? Value { get; set; }

  [NotMapped]
  public string? ValueText { get => $"${Value:N2}"; }

  public int? Type { get; set; }

  public TransactionStatus StatusId { get; set; }

  public string? Status { get => StatusId.ToString(); }

  public DateTime? TransactionDate { get; set; }

  [NotMapped]
  public DateOnly? TransactionDateOnly { get => TransactionDate == null ? null : DateOnly.FromDateTime(TransactionDate.GetValueOrDefault()); }

  [NotMapped]
  public TimeOnly? TransactionTimeOnly { get => TransactionDate == null ? null : TimeOnly.FromDateTime(TransactionDate.GetValueOrDefault()); }

  public DateTime DateModified { get; set; }

  public DateTime DateCreated { get; set; }

}

#endregion

#region Config

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
  public void Configure(EntityTypeBuilder<Transaction> builder)
  {
    builder.Property(e => e.StatusId).HasDefaultValue(TransactionStatus.Initiated);
    builder.Property(e => e.DateCreated).HasDefaultValueSql("(GETUTCDATE())");
    builder.Property(e => e.DateModified).HasDefaultValueSql("(GETUTCDATE())");
  }
}

#endregion
