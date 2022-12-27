namespace Notificator.Data.Entities;

public class Topic
{
    public long TopicId { get; set; }

    /// <summary>
    /// Unique name to identify the topic.
    /// </summary>
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}