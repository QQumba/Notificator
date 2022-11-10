namespace Notificator.Data.Entities;

public class Message
{
    public long MessageId { get; set; }

    public string JsonPayload { get; set; } = null!;

    public long ClientId { get; set; }

    /// <summary>
    /// Defines recipient channels of that message.
    /// </summary>
    public IEnumerable<long> ChannelIds { get; set; } = null!;
}