using Microsoft.EntityFrameworkCore;
using MVCWebApplication1.Data.Enums;
using MVCWebApplication1.Models;

namespace MVCWebApplication1.Data
{
  public class Seed
  {
    public static async Task SeedTransactionsAsync(IApplicationBuilder applicationBuilder)
    {
      using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
      var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>()!;

      await context.Database.EnsureCreatedAsync();
      bool exists = await context.Transactions.AnyAsync();
      if (!exists)
      {
        await context.Transactions.AddRangeAsync(new List<Transaction>()
        {
            new()
            {
              Description = "Deposit to Balanced Mutual Fund Index",
              Reference = "3rh8794939hrwekfueh4j8095ht9853t",
              Amount = 200,
              StatusId = TransactionStatus.Initiated,
              Type = 700,
              Value = 150,
              TransactionDate = new DateTime(2023, 7, 6, 23, 0, 40),
            },
            new()
            {
              Description = "Deposit to Balanced Mutual Fund Index",
              Reference = "3rh8794939hrwekfueh4j8095ht9853t",
              Amount = 100,
              StatusId = TransactionStatus.Completed,
              Type = 300,
              Value = 100,
              TransactionDate = new DateTime(2024, 7, 3, 10, 3, 21),
            },
        });
        await context.SaveChangesAsync();
      }

    }

  }
}