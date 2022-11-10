using Microsoft.EntityFrameworkCore;
using Notificator.Data.Entities;
using Notificator.Data.Entities.Enums;
using Notificator.Data.Util;
using Telegram.Bot;

namespace Notificator.Data.Services;

public class TelegramPublishHandler : IPublishHandler
{
    private readonly NotificatorDbContext _context;
    private readonly ITelegramBotClient _botClient;

    public TelegramPublishHandler(NotificatorDbContext context, ITelegramBotClient botClient)
    {
        _context = context;
        _botClient = botClient;
    }

    public async Task HandlePublish(Message message)
    {
        var consumers = await _context.Consumers
            .Where(x => message.ChannelIds.Contains(x.ChannelId) && x.ConsumerType == ConsumerType.Telegram)
            .ToListAsync();

        foreach (var consumer in consumers)
        {
            var chatId = consumer.GetTelegramConsumerAddress()!.ChatId;
            await _botClient.SendTextMessageAsync(chatId, message.JsonPayload);
        }
    }
}

public class TelegramConsumerAddress
{
    public long ChatId { get; set; }
}