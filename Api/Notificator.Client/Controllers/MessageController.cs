using Microsoft.AspNetCore.Mvc;
using Notificator.Client.Data;

namespace Notificator.Client.Controllers;

[ApiController]
[Route("message")]
public class MessageController : ControllerBase
{
    private readonly InMemoryMessageRepository _repository;

    public MessageController(InMemoryMessageRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Message> GetMessage(int id)
    {
        var message = _repository.GetMessage(id);
        if (message is null)
        {
            return NotFound();
        }

        return Ok(message);
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<Message>> GetAllMessages()
    {
        var messages = _repository.GetAllMessages();
        return Ok(messages);
    }

    [HttpPost]
    public ActionResult<Message> CreateMessage(Message message)
    {
        var createdMessage = _repository.CreateMessage(message);
        return Ok(createdMessage);
    }
}