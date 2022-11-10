using Microsoft.EntityFrameworkCore;
using Notificator.Data.Entities;
using Notificator.Data.Entities.Enums;
using Notificator.Data.Util;

namespace Notificator.Data.Services;

public class WebhookPublishHandler : IPublishHandler
{
    private readonly HttpClient _client;
    private readonly NotificatorDbContext _context;

    public WebhookPublishHandler(HttpClient client, NotificatorDbContext context)
    {
        _client = client;
        _context = context;
    }

    public async Task HandlePublish(Message message)
    {
        var consumers = await _context.Consumers
            .Where(x => x.ConsumerType == ConsumerType.Webhook && message.ChannelIds.Contains(x.ChannelId))
            .ToListAsync();
        
        foreach (var consumer in consumers)
        {
            var url = consumer.GetWebhookConsumerAddress()!.Url;
            await CallWebhook(url, message.JsonPayload);
        }
    }

    private async Task CallWebhook(string url, string jsonPayload)
    {
        var content = new StringContent(jsonPayload);
        await _client.PostAsync(url, content);
    }
}

public class WebhookConsumerAddress
{
    public string Url { get; set; } = null!;
}