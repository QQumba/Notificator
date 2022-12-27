using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Notificator.Data.Clients;
using Notificator.Data.DataTransferObjects;
using Notificator.Data.Entities;
using Notificator.Data.Entities.Enums;

namespace Notificator.Data.Services;

public class WebhookPublishHandler : IPublishHandler
{
    private readonly IWebhookClient _client;
    private readonly NotificatorDbContext _context;

    public WebhookPublishHandler(IWebhookClient client, NotificatorDbContext context)
    {
        _client = client;
        _context = context;
    }

    public async Task HandlePublish(Message message)
    {
        var consumers = await _context.Consumers
            .Where(x => x.TopicId == message.TopicId && x.ConsumerType == ConsumerType.Webhook)
            .ToListAsync();

        foreach (var consumer in consumers)
        {
            await CallWebhook(consumer.Address, message.Payload);
        }
    }

    private async Task CallWebhook(string url, string jsonPayload)
    {
        var message = new MessageData { Data = jsonPayload };
        var content = JsonContent.Create(message);
        await _client.NotifyAsync(url, content);
    }
}