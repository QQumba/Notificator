using Notificator.Data.Entities;
using Notificator.Data.Entities.Enums;
using Notificator.Data.Services.Interfaces;

namespace Notificator.Data.Services;

public class ConsumerService : IConsumerService
{
    private readonly NotificatorDbContext _context;

    public ConsumerService(NotificatorDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Consumer> GetConsumers(long channelId, ConsumerType typeEnum)
    {
        return Enumerable.Empty<Consumer>();
    }

    public bool AddConsumer(Consumer consumer)
    {
        throw new NotImplementedException();
    }
}