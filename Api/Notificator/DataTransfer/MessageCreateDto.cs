namespace Notificator.DataTransfer;

public class MessageCreateDto
{
    public string Payload { get; set; } = null!;

    public long TopicId { get; set; }
}