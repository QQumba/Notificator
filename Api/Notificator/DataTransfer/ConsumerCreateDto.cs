using Notificator.Data.Entities.Enums;

namespace Notificator.DataTransfer;

public class ConsumerCreateDto
{
    public string JsonAddress { get; set; } = null!;

    public ConsumerType ConsumerType { get; set; }

    public long TopicId { get; set; }
}