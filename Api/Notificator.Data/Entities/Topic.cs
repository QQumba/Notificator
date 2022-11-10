using Notificator.Data.Entities.Enums;

namespace Notificator.Data.Entities;

public class Topic
{
    public long TopicId { get; set; }
    
    public long ChannelId { get; set; }

    public string StringId { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public ConsumerType ConsumerType { get; set; }

    /// <summary>
    /// Refers to a mechanism to transform data for  
    /// </summary>
    public long? DataTransformId { get; set; }
}