using CurrencyMonitor.Api.Data;
using CurrencyMonitor.Api.Interfaces;
using CurrencyMonitor.Api.Services;
using CurrencyMonitor.Api.Workers;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

string connection = builder.Configuration.GetConnectionString("AvailabilityRecordDB");

builder.Services.AddDbContext<CurrencyMonitorDbContext>(options =>
    options.UseNpgsql(connection));

builder.Services.AddScoped<ICurrencyMonitorDbContext>(sp =>
    (ICurrencyMonitorDbContext)sp.GetRequiredService<CurrencyMonitorDbContext>());

builder.Services.AddScoped<IProcessService, ProcessService>();
builder.Services.AddScoped<IApiService, BanckApiService>();
builder.Services.AddScoped<IAvailabilityRecordService, AvailabilityRecordService>();

builder.Services.AddHostedService<CurrencyWorker>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CurrencyMonitorDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.Run();