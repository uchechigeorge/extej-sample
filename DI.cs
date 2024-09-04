using MVCWebApplication1.Interfaces;
using MVCWebApplication1.Repositories;

namespace MVCWebApplication1;

public class DI
{
  public static void RegisterServices(IServiceCollection services)
  {
    services.AddScoped<ITransactionRepository, TransactionRepository>();
  }
}