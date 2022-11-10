using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Notificator.TelegramBot;

public class BotRunner
{
    private const string BotAccessToken = "5628321676:AAHI1uqf2d-IjMsyAq5pFccqoLWImW425m8";

    /// <summary>
    /// Block thread
    /// </summary>
    public void Run()
    {
        var botClient = new TelegramBotClient(BotAccessToken);

        var cts = new CancellationTokenSource();

        // whatever
        var receiverOption = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>(),
        };

        botClient.StartReceiving(
            HandleUpdateAsync,
            HandlePollingErrorAsync,
            receiverOption,
            cts.Token
        );

        Console.Read();
        cts.Cancel();
    }

    private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken ct)
    {
        // Only process Message updates: https://core.telegram.org/bots/api#message
        if (update.Message is not { } message)
        {
            return;
        }

        // Only process text messages
        if (message.Text is not { } messageText)
        {
            return;
        }

        var chatId = message.Chat.Id;
        var chatTitle = message.Chat.Title;

        Console.WriteLine($"Received a '{messageText}' message in chat {chatTitle}.");

        // Echo received message text
        var sentMessage = await client.SendTextMessageAsync(
            chatId,
            "You said:\n" + messageText,
            cancellationToken: ct);
    }

    private Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken ct)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }
}