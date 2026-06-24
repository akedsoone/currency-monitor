using CurrencyMonitor.Web.Data;
using CurrencyMonitor.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("AvailabilityRecordDB")!;
builder.Services.AddDbContext<CurrencyMonitorDbContext>(options =>
    options.UseNpgsql(connection));
builder.Services.AddScoped<ICurrencyMonitorDbContext>(sp =>
    (ICurrencyMonitorDbContext)sp.GetRequiredService<CurrencyMonitorDbContext>());

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();