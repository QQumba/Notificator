using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace Notificator.TelegramBot.Services;

public class ReceiverService
{
    private readonly ITelegramBotClient _botClient;
    private readonly UpdateHandler _updateHandlers;
    private readonly ILogger<ReceiverService> _logger;

    public ReceiverService(
        ITelegramBotClient botClient,
        UpdateHandler updateHandler,
        ILogger<ReceiverService> logger)
    {
        _botClient = botClient;
        _updateHandlers = updateHandler;
        _logger = logger;
    }

    /// <summary>
    /// Start to service Updates with provided Update Handler class
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public async Task ReceiveAsync(CancellationToken stoppingToken)
    {
        // ToDo: we can inject ReceiverOptions through IOptions container
        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = Array.Empty<UpdateType>(),
            ThrowPendingUpdates = true,
        };

        var me = await _botClient.GetMeAsync(stoppingToken);
        _logger.LogInformation("Start receiving updates for {BotName}", me.Username ?? "My Awesome Bot");

        // Start receiving updates
        await _botClient.ReceiveAsync(
            updateHandler: _updateHandlers,
            receiverOptions: receiverOptions,
            cancellationToken: stoppingToken);
    }
}