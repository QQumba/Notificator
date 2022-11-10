using Notificator.Data.Entities;
using Notificator.Data.Entities.Enums;

namespace Notificator.Data.Services.Interfaces;

public interface IConsumerService
{
    IEnumerable<Consumer> GetConsumers(long channelId, ConsumerType typeEnum);

    bool AddConsumer(Consumer consumer);
}