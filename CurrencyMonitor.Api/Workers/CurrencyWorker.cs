using CurrencyMonitor.Api.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CurrencyMonitor.Api.Workers
{
    public class CurrencyWorker(
        ILogger<CurrencyWorker> logger,
        IProcessService processService) : BackgroundService
    {
        private readonly ILogger<CurrencyWorker> _logger = logger;
        private readonly IProcessService _processService = processService ?? throw new ArgumentNullException(nameof(processService));

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("CurrencyWorker started at {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _processService.ProcessAsync();
                    _logger.LogInformation("Work cycle completed at {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "CurrencyWorker failed");
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CurrencyWorker stopping at {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}