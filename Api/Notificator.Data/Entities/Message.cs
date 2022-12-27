namespace Notificator.Data.Entities;

public class Message
{
    public long MessageId { get; set; }

    public string Payload { get; set; } = null!;

    /// <summary>
    /// Defines recipient channel of that message.
    /// </summary>
    public long TopicId { get; set; }
}