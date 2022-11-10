using Notificator.Data.Entities.Enums;

namespace Notificator.Data.Entities;

public class Consumer
{
    public long ConsumerId { get; set; }

    public long ChannelId { get; set; }

    public string JsonAddress { get; set; } = null!;

    public ConsumerType ConsumerType { get; set; }

    public long TopicId { get; set; }
}