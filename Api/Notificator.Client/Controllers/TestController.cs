using Microsoft.AspNetCore.Mvc;

namespace Notificator.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<string> SendMessage(MessageData message)
    {
        _logger.LogError("message received: {Message}", message.Data);
        return message.Data;
    }
}

public class MessageData
{
    public string Data { get; set; }
}