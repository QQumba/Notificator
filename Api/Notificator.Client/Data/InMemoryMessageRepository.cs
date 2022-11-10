namespace Notificator.Client.Data;

public class InMemoryMessageRepository
{
    private readonly List<Message> _messages = new();

    public Message? GetMessage(int id)
    {
        var message = _messages.FirstOrDefault(m => m.Id == id);
        return message;
    }

    public IEnumerable<Message> GetAllMessages()
    {
        return _messages;
    }

    public Message CreateMessage(Message message)
    {
        var id = 1;
        if (_messages.Any())
        {
            id = _messages.OrderByDescending(m => m.Id).First().Id + 1;
        }

        var messageToAdd = new Message
        {
            Id = id,
            Payload = message.Payload,
            Sender = message.Sender
        };
        _messages.Add(messageToAdd);

        return messageToAdd;
    }
}