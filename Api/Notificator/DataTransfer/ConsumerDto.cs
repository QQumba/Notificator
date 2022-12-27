using Notificator.Data.Entities.Enums;

namespace Notificator.DataTransfer;

public class ConsumerDto
{
    public long ConsumerId { get; set; }

    public string Address { get; set; } = null!;

    public long TopicId { get; set; }

    public ConsumerType ConsumerType { get; set; }
}