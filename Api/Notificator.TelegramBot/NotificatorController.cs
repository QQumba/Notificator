using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Notificator.TelegramBot;

[ApiController]
[Route("[controller]")]
public class NotificatorController : ControllerBase
{
    private readonly ILogger<NotificatorController> _logger;
    private readonly ITelegramBotClient _botClient;

    public NotificatorController(ILogger<NotificatorController> logger, ITelegramBotClient botClient)
    {
        _logger = logger;
        _botClient = botClient;
    }

    // TODO: find a way to register chat id per client per notification channel
    [HttpPost]
    public async Task<ActionResult> SendMessage(CancellationToken ct)
    {
        const int chatId = 0;
        const string messageText = "";
        
        await SendMessage(chatId, messageText, ct);
        return Ok();
    }

    private async Task SendMessage(long chatId, string messageText, CancellationToken cancellationToken)
    {
        await _botClient.SendTextMessageAsync(chatId, messageText, cancellationToken: cancellationToken);
    }
}