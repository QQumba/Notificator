using Notificator.Data.Entities;

namespace Notificator.Data.Services;

public class MessagingService
{
    public void Subscribe(Channel channel, ISubscribeStrategy subscribeStrategy)
    {
        subscribeStrategy.Subscribe(channel);
    }

    public void Publish(Message message)
    {
        
    }
}

public interface ISubscribeStrategy
{
    void Subscribe(Channel channel);
}

public class WebhookSubscriptionStrategy : ISubscribeStrategy
{
    public void Subscribe(Channel channel)
    {
        
    }
}

