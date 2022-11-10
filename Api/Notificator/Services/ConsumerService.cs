using Mapster;
using Microsoft.EntityFrameworkCore;
using Notificator.Data;
using Notificator.Data.Entities;
using Notificator.DataTransfer;

namespace Notificator.Services;

public interface IConsumerService
{
    Task<ConsumerDto?> CreateConsumer(ConsumerCreateDto consumer);
}

public class ConsumerService : IConsumerService
{
    private readonly NotificatorDbContext _context;

    public ConsumerService(NotificatorDbContext context)
    {
        _context = context;
    }

    public async Task<ConsumerDto?> CreateConsumer(ConsumerCreateDto consumer)
    {
        var topic = await _context.Topics.FirstOrDefaultAsync(x =>
            x.TopicId == consumer.TopicId &&
            x.ConsumerType == consumer.ConsumerType);

        if (topic is null)
        {
            return null;
        }

        var consumerAlreadyExists = await _context.Consumers.AnyAsync(x =>
            x.JsonAddress.Equals(consumer.JsonAddress) && x.TopicId == topic.TopicId);

        if (consumerAlreadyExists)
        {
            return null;
        }

        var consumerEntity = consumer.Adapt<Consumer>();
        var createdConsumer = _context.Consumers.Add(consumerEntity).Entity;

        await _context.SaveChangesAsync();
        return createdConsumer.Adapt<ConsumerDto>();
    }

    public async Task<IEnumerable<ConsumerDto>> GetConsumersByChannelId(long channelId)
    {
        var consumers = await _context.Consumers.Where(x => x.ChannelId == channelId).ToListAsync();
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