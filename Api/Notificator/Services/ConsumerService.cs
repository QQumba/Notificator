using Mapster;
using Microsoft.EntityFrameworkCore;
using Notificator.Data;
using Notificator.Data.Entities;
using Notificator.DataTransfer;

namespace Notificator.Services;

public interface IConsumerService
{
    Task<ConsumerDto?> AddConsumer(ConsumerCreateDto consumer);
    Task<IEnumerable<ConsumerDto>> GetConsumers(long topicId);

    Task<IEnumerable<ConsumerDto>> GetAllConsumers();
    Task<bool> RemoveConsumer(long consumerId);
}

public class ConsumerService : IConsumerService
{
    private readonly NotificatorDbContext _context;

    public ConsumerService(NotificatorDbContext context)
    {
        _context = context;
    }

    public async Task<ConsumerDto?> AddConsumer(ConsumerCreateDto consumer)
    {
        var topic = await _context.Topics.FirstOrDefaultAsync(x => x.TopicId == consumer.TopicId);

        if (topic is null)
        {
            return null;
        }

        var consumerAlreadyExists = await _context.Consumers.AnyAsync(x =>
            x.Address.Equals(consumer.Address) &&
            x.TopicId == topic.TopicId &&
            x.ConsumerType == consumer.ConsumerType);

        if (consumerAlreadyExists)
        {
            return null;
        }

        var consumerEntity = consumer.Adapt<Consumer>();
        consumerEntity.TopicId = topic.TopicId;

        var createdConsumer = _context.Consumers.Add(consumerEntity);

        await _context.SaveChangesAsync();
        return createdConsumer.Entity.Adapt<ConsumerDto>();
    }

    public async Task<IEnumerable<ConsumerDto>> GetConsumers(long topicId)
    {
        var consumers = await _context.Consumers
            .Where(x => x.TopicId == topicId)
            .ToListAsync();

        return consumers.Select(x => x.Adapt<ConsumerDto>());
    }

    public async Task<IEnumerable<ConsumerDto>> GetAllConsumers()
    {
        var consumers = await _context.Consumers.ToListAsync();
        return consumers.Select(x => x.Adapt<ConsumerDto>());
    }

    public async Task<bool> RemoveConsumer(long consumerId)
    {
        var consumer = await _context.Consumers.FirstOrDefaultAsync(x => x.ConsumerId == consumerId);

        if (consumer is null)
        {
            return false;
        }

        _context.Remove(consumer);
        await _context.SaveChangesAsync();

        return true;
    }
}