using Notificator.Data.Entities.Enums;

namespace Notificator.DataTransfer;

public class ConsumerDto
{
    public long ConsumerId { get; set; }

    public long ChannelId { get; set; }

    public string JsonAddress { get; set; } = null!;

    public ConsumerType ConsumerType { get; set; }
}