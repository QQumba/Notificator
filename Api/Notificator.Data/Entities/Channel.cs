using Notificator.Data.Entities.Enums;

namespace Notificator.Data.Entities;

/// <summary>
/// Client unique entity to publish/consume a certain message.
/// </summary>
public class Channel
{
    public long ChannelId { get; set; }

    public string StringId { get; set; } = null!;
    
    public string Description { get; set; } = null!;


    public long ClientId { get; set; }
}