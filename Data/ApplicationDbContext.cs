using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MVCWebApplication1.Models;
using MVCWebApplication1.Helpers;

namespace MVCWebApplication1.Data;

public class ApplicationDbContext : DbContext
{

  #region Constructor

  public ApplicationDbContext()
  {

  }

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
  {
  }

  #endregion

  #region Properties

  public virtual DbSet<Transaction> Transactions { get; set; }

  #endregion

  #region  Methods

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);

    if (IoCContainer.Configuration != null)
    {
      if ((IoCContainer.Configuration["Db:EnableSensitiveDataLogging"] ?? "").GetBoolean())
      {
        optionsBuilder.EnableSensitiveDataLogging();
      }

    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    modelBuilder.HasDefaultSchema("dbo");
  }

  #endregion

}