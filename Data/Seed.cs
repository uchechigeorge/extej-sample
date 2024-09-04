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
              Value = 1500,
              TransactionDate = new DateTime(2023, 7, 6, 23, 0, 40),
          },
          new()
          {
              Description = "Deposit to Balanced Mutual Fund Index",
              Reference = "3rh8794939hrwekfueh4j8095ht9853t",
              Amount = 100,
              StatusId = TransactionStatus.Completed,
              Type = 300,
              Value = 1000,
              TransactionDate = new DateTime(2024, 7, 3, 10, 3, 21),
          },
          new()
          {
              Description = "Withdrawal from High-Yield Savings",
              Reference = "hfjr8304939hrwekfueh4j8095ht9dj2",
              Amount = 150,
              StatusId = TransactionStatus.Initiated,
              Type = 400,
              Value = 1400,
              TransactionDate = new DateTime(2023, 8, 15, 14, 20, 35),
          },
          new()
          {
              Description = "Deposit to Stock Market ETF",
              Reference = "5kjsd839f0djskdfj38jd93jd93jd93k",
              Amount = 300,
              StatusId = TransactionStatus.Completed,
              Type = 800,
              Value = 2900,
              TransactionDate = new DateTime(2024, 6, 20, 9, 30, 0),
          },
          new()
          {
              Description = "Transfer to Retirement Account",
              Reference = "29fj309f3h8r8fh38r93fj93f3f93f3",
              Amount = 500,
              StatusId = TransactionStatus.Initiated,
              Type = 200,
              Value = 4900,
              TransactionDate = new DateTime(2024, 4, 10, 11, 15, 45),
          },
          new()
          {
              Description = "Withdrawal from Brokerage Account",
              Reference = "fj39f3j8r3j839j839fj3f93j93j9f9f",
              Amount = 250,
              StatusId = TransactionStatus.Completed,
              Type = 600,
              Value = 2400,
              TransactionDate = new DateTime(2024, 3, 25, 16, 50, 12),
          },
          new()
          {
              Description = "Deposit to Balanced Mutual Fund Index",
              Reference = "kd930d9fj39jf39j3f39f39fj39j3f93",
              Amount = 100,
              StatusId = TransactionStatus.Initiated,
              Type = 700,
              Value = 950,
              TransactionDate = new DateTime(2023, 12, 5, 13, 40, 30),
          },
          new()
          {
              Description = "Transfer to Bond Market Fund",
              Reference = "fj38rj8rj9j9j9djf38dj9f8d9f9fjf",
              Amount = 350,
              StatusId = TransactionStatus.Completed,
              Type = 500,
              Value = 3400,
              TransactionDate = new DateTime(2024, 5, 22, 12, 10, 5),
          },
          new()
          {
              Description = "Deposit to International Fund",
              Reference = "djf8j39r9jr9j9j9djf8j8dj8dj8dj8",
              Amount = 400,
              StatusId = TransactionStatus.Initiated,
              Type = 900,
              Value = 3800,
              TransactionDate = new DateTime(2024, 1, 19, 15, 55, 25),
          },
          new()
          {
              Description = "Withdrawal from Money Market Fund",
              Reference = "kdf98d9f8d8f8f8djf8d8f8d8f8djf8",
              Amount = 500,
              StatusId = TransactionStatus.Completed,
              Type = 300,
              Value = 4800,
              TransactionDate = new DateTime(2023, 9, 27, 17, 25, 30),
          },
          new()
          {
              Description = "Deposit to Real Estate Fund",
              Reference = "9djf9jf9jf9jfjfjfjfjfjfjfjfjfjf9j",
              Amount = 600,
              StatusId = TransactionStatus.Initiated,
              Type = 600,
              Value = 5900,
              TransactionDate = new DateTime(2024, 2, 14, 14, 35, 40),
          },
          new()
          {
              Description = "Transfer to Cash Account",
              Reference = "0r9jr9fj9fj9fjf9fj9fj9f9f9f9f9f9",
              Amount = 700,
              StatusId = TransactionStatus.Completed,
              Type = 100,
              Value = 6800,
              TransactionDate = new DateTime(2023, 11, 3, 18, 20, 50),
          },
          new()
          {
              Description = "Deposit to Growth Stock Fund",
              Reference = "f93fjf9jfjfjfjfjfjfjfjfjfjfjfjfjf",
              Amount = 800,
              StatusId = TransactionStatus.Initiated,
              Type = 200,
              Value = 7900,
              TransactionDate = new DateTime(2023, 10, 10, 19, 0, 10),
          },
          new()
          {
              Description = "Withdrawal from Income Fund",
              Reference = "r9r9r9r9r9r9r9r9r9r9r9r9r9r9r9r",
              Amount = 900,
              StatusId = TransactionStatus.Completed,
              Type = 400,
              Value = 8900,
              TransactionDate = new DateTime(2024, 8, 30, 8, 40, 20),
          },
          new()
          {
              Description = "Deposit to Index Fund",
              Reference = "jfjfjfjfjfjfjfjfjfjfjfjfjfjfjfjfj",
              Amount = 1000,
              StatusId = TransactionStatus.Initiated,
              Type = 800,
              Value = 9800,
              TransactionDate = new DateTime(2024, 6, 7, 20, 45, 30),
          },
          new()
          {
              Description = "Transfer to Equity Fund",
              Reference = "9fjf9f9f9f9f9f9f9f9f9f9f9f9f9f9",
              Amount = 1100,
              StatusId = TransactionStatus.Completed,
              Type = 900,
              Value = 1080,
              TransactionDate = new DateTime(2024, 3, 18, 21, 50, 40),
          },
          new()
          {
              Description = "Withdrawal from Treasury Bonds",
              Reference = "fjf8f8f8f8f8f8f8f8f8f8f8f8f8f8f",
              Amount = 1200,
              StatusId = TransactionStatus.Initiated,
              Type = 100,
              Value = 1180,
              TransactionDate = new DateTime(2023, 8, 5, 22, 55, 50),
          },
          new()
          {
              Description = "Deposit to Foreign Bonds",
              Reference = "9fjf9f9f9f9f9f9f9f9f9f9f9f9f9f9",
              Amount = 1300,
              StatusId = TransactionStatus.Completed,
              Type = 400,
              Value = 1280,
              TransactionDate = new DateTime(2024, 1, 24, 23, 0, 0),
          },
          new()
          {
              Description = "Transfer to Precious Metals Fund",
              Reference = "f8f8f8f8f8f8f8f8f8f8f8f8f8f8f8f",
              Amount = 1400,
              StatusId = TransactionStatus.Initiated,
              Type = 700,
              Value = 1380,
              TransactionDate = new DateTime(2024, 9, 12, 7, 5, 10),
          },
          new()
          {
              Description = "Deposit to High-Yield Bond Fund",
              Reference = "fjf9f9f9f9f9f9f9f9f9f9f9f9f9f9f",
              Amount = 1500,
              StatusId = TransactionStatus.Completed,
              Type = 900,
              Value = 1480,
              TransactionDate = new DateTime(2023, 7, 1, 6, 10, 20),
          },
        });
        await context.SaveChangesAsync();
      }

    }

  }
}