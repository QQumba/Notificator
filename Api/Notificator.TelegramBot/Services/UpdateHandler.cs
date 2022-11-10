using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Notificator.TelegramBot.Services;

public class UpdateHandler : IUpdateHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly ILogger<UpdateHandler> _logger;

    public UpdateHandler(ITelegramBotClient botClient, ILogger<UpdateHandler> logger)
    {
        _botClient = botClient;
        _logger = logger;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        var handler = update switch
        {
            { Message: { } message } => EchoMessage(message, cancellationToken),
            _ => Task.CompletedTask
        };

        await handler;
    }

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException =>
                $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        _logger.LogInformation("HandleError: {ErrorMessage}", ErrorMessage);

        // Cooldown in case of network connection error
        if (exception is RequestException)
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
    }

    private async Task EchoMessage(Message message, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Receive message type: {MessageType}", message.Type);

        await _botClient.SendTextMessageAsync(message.Chat.Id, message.Text, cancellationToken: cancellationToken);
    }
}