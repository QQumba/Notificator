using Microsoft.AspNetCore.Mvc;

namespace Notificator.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{

}

public class TestResult
{
    public int Value { get; set; }
}