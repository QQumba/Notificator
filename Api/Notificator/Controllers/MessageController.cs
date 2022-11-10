using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Notificator.DataTransfer;
using Notificator.Services;

namespace Notificator.Controllers;

[ApiController]
[Route("test")]
public class MessageController : ControllerBase
{
    private readonly WebhookService _webhookService;
    private readonly IValidator<Message> _messageValidator;

    public MessageController(WebhookService webhookService, IValidator<Message> messageValidator)
    {
        _webhookService = webhookService;
        _messageValidator = messageValidator;
    }

    [HttpPost]
    public async Task<ActionResult<WebhookMessagingResult>> SendMessage(Message message, [FromServices] IValidator<Message> validator)
    {
        var validationResult = validator.Validate(message);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var result = await _webhookService.NotifyAll(message);
        return Ok(result);
    }
}