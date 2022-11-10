using Microsoft.AspNetCore.Mvc;
using Notificator.Services;

namespace Notificator.Controllers;

[ApiController]
[Route("webhook")]
public class WebhookController : ControllerBase
{
    private readonly WebhookService _webhookService;

    public WebhookController(WebhookService webhookService)
    {
        _webhookService = webhookService;
    }
    
    [HttpPost("subscribe")]
    public ActionResult<bool> Subscribe(string callbackUrl)
    {
        var result = _webhookService.Subscribe(callbackUrl);
        return Ok(result);
    }
    
    [HttpPost("unsubscribe")]
    public ActionResult<bool> Unsubscribe(string callbackUrl)
    {
        var result = _webhookService.Unsubscribe(callbackUrl);
        return Ok(result);
    }

    [HttpGet("all")]
    public ActionResult<IEnumerable<string>> ViewSubscribers()
    {
        return Ok(_webhookService.Subscribers);
    }
}