using MediatR;
using Notificator.Data.Entities;

namespace Notificator.Data.Events;

public class MessagePublished : INotification
{
    public MessagePublished(Message message)
    {
        Message = message;
    }

    public Message Message { get; }
}