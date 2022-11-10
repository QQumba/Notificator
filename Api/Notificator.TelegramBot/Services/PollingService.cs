namespace Notificator.TelegramBot.Services;

public class PollingService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public PollingService(IServiceProvider serviceProvider, ILogger<PollingService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                // get something from _serviceProvider and do some work
                using var scope = _serviceProvider.CreateScope();
                var receiver = scope.ServiceProvider.GetRequiredService<ReceiverService>();

                await receiver.ReceiveAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError("Polling failed with exception: {Exception}", e);

                Console.WriteLine(e);
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }
    }
}