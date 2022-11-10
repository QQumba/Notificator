using Microsoft.AspNetCore.Mvc;

namespace Notificator.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> SendMessage(string message)
    {
        return message;
    }
}