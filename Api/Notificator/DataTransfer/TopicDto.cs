namespace Notificator.DataTransfer;

public class TopicDto
{
    public long TopicId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}