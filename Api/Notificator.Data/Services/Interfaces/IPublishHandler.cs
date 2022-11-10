using Notificator.Data.Entities;

namespace Notificator.Data.Services;

public interface IPublishHandler
{
    Task HandlePublish(Message message);
}