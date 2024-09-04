using Microsoft.EntityFrameworkCore;
using MVCWebApplication1;
using MVCWebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);
IoCContainer.Configuration = builder.Configuration;
DI.RegisterServices(builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseSqlServer(IoCContainer.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

if (args.Length == 1 && args[0].Equals("seeddata", StringComparison.CurrentCultureIgnoreCase))
{
  await Seed.SeedTransactionsAsync(app);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
