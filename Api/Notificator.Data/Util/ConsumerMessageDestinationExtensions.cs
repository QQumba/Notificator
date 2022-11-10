using System.Text.Json;
using Notificator.Data.Entities;
using Notificator.Data.Services;

namespace Notificator.Data.Util;

public static class ConsumerMessageDestinationExtensions
{
    public static WebhookConsumerAddress? GetWebhookConsumerAddress(this Consumer webhookConsumer)
    {
        var webhookMessageDestination = 
            JsonSerializer.Deserialize<WebhookConsumerAddress>(webhookConsumer.JsonAddress);
        
        return webhookMessageDestination;
    }
    
    public static TelegramConsumerAddress? GetTelegramConsumerAddress(this Consumer telegramConsumer)
    {
        var telegramConsumerAddress = 
            JsonSerializer.Deserialize<TelegramConsumerAddress>(telegramConsumer.JsonAddress);
        
        return telegramConsumerAddress;
    }
}