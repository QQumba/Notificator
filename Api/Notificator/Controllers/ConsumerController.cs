using Microsoft.AspNetCore.Mvc;
using Notificator.DataTransfer;
using Notificator.Services;

namespace Notificator.Controllers;

[ApiController]
[Route("api/consumer")]
public class ConsumerController : ControllerBase
{
    private readonly IConsumerService _consumerService;

    public ConsumerController(IConsumerService consumerService)
    {
        _consumerService = consumerService;
    }

    [HttpPost("subscribe")]
    public async Task<ActionResult<bool>> Subscribe(ConsumerCreateDto consumer)
    {
        var result = await _consumerService.AddConsumer(consumer);
        if (result is null)
        {
            return BadRequest("Consumer creation error.");
        }

        return Ok(result);
    }

    [HttpPost("unsubscribe")]
    public async Task<ActionResult<bool>> Unsubscribe(long consumerId)
    {
        var result = await _consumerService.RemoveConsumer(consumerId);
        if (!result)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<ConsumerDto>>> ViewSubscribers()
    {
        var consumers = await _consumerService.GetAllConsumers();
        return Ok(consumers);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConsumerDto>>> GetConsumers(long topicId)
    {
        var consumers = await _consumerService.GetConsumers(topicId);
        return Ok(consumers);
    }
}