using Notificator.Data.Entities.Enums;

namespace Notificator.Data.Entities;

public class Consumer
{
    public long ConsumerId { get; set; }

    public string Address { get; set; } = null!;

    public ConsumerType ConsumerType { get; set; }

    public long TopicId { get; set; }
}