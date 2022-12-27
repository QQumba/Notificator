using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Notificator.Data;
using Notificator.Data.Entities;
using Notificator.Data.Services;
using Notificator.DataTransfer;

namespace Notificator.Services;

public class PublishService
{
    private readonly NotificatorDbContext _context;
    private readonly List<IPublishHandler> _handlers;

    public PublishService(NotificatorDbContext context,
        WebhookPublishHandler webhookPublishHandler,
        EmailPublishHandler emailPublishHandler,
        TelegramPublishHandler telegramPublishHandler)
    {
        _context = context;
        _handlers = new List<IPublishHandler>
        {
            webhookPublishHandler,
            emailPublishHandler,
            telegramPublishHandler
        };
    }

    public async Task<Message?> PublishMessage(MessageCreateDto messageCreate)
    {
        var message = await CreateMessage(messageCreate.TopicId, messageCreate.Payload);
        if (message is null)
        {
            return null;
        }

        foreach (var handler in _handlers)
        {
            await handler.HandlePublish(message);
        }

        return message;
    }

    public async Task<TopicDto?> CreateTopic(TopicCreateDto topic)
    {
        var topicAlreadyExists = await _context.Topics.AnyAsync(x => x.Name == topic.Name);

        if (topicAlreadyExists)
        {
            return null;
        }

        var createdTopic = _context.Topics.Add(topic.Adapt<Topic>()).Entity;
        await _context.SaveChangesAsync();
        return createdTopic.Adapt<TopicDto>();
    }

    public async Task<IEnumerable<TopicDto>> GetAllTopics()
    {
        var topics = await _context.Topics.ToListAsync();
        return topics.Select(x => x.Adapt<TopicDto>());
    }

    public async Task<IEnumerable<Message>> GetTopicMessages(long topicId)
    {
        var messages = await _context.Messages
            .Where(x => x.TopicId == topicId)
            .ToListAsync();
        return messages;
    }

    private async Task<Message?> CreateMessage(long topicId, string messagePayload)
    {
        var topic = await _context.Topics
            .FirstOrDefaultAsync(x => x.TopicId == topicId);

        if (topic is null)
        {
            return null;
        }

        var message = new Message
        {
            Payload = messagePayload,
            TopicId = topicId
        };

        var createdMessage = _context.Messages.Add(message).Entity;
        await _context.SaveChangesAsync();

        return createdMessage;
    }
}