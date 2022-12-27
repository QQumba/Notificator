using Microsoft.AspNetCore.Mvc;
using Notificator.DataTransfer;
using Notificator.Services;

namespace Notificator.Controllers;

[ApiController]
[Route("api/topic")]
public class TopicController : ControllerBase
{
    private readonly PublishService _publishService;

    public TopicController(PublishService publishService)
    {
        _publishService = publishService;
    }

    [HttpPost("publish")]
    public async Task<ActionResult> PublishMessage(MessageCreateDto messageCreateDto)
    {
        var message = await _publishService.PublishMessage(messageCreateDto);
        if (message is null)
        {
            return BadRequest("Message was not created");
        }

        return Ok(message);
    }

    [HttpPost]
    public async Task<ActionResult<TopicDto>> CreateTopic(TopicCreateDto topic)
    {
        var result = await _publishService.CreateTopic(topic);
        if (result is null)
        {
            return BadRequest("Topic creation error");
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TopicDto>>> GetAllTopics()
    {
        var topics = await _publishService.GetAllTopics();
        return Ok(topics);
    }

    [HttpGet("{topicId:long}/messages")]
    public async Task<ActionResult<IEnumerable<TopicDto>>> GetTopicMessages(long topicId)
    {
        var messages = await _publishService.GetTopicMessages(topicId);
        return Ok(messages);
    }
}