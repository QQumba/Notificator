namespace Notificator.TelegramBot.Util;

public class LoggingMessageHandler : DelegatingHandler
{
    private readonly ILogger<LoggingMessageHandler> _logger;

    public LoggingMessageHandler(IServiceProvider serviceProvider)
    {
        _logger = serviceProvider.GetService<ILogger<LoggingMessageHandler>>()!;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        await LogHttpRequestBody(request, cancellationToken);
        var response = await base.SendAsync(request, cancellationToken);
        await LogHttpResponseBody(response, cancellationToken);

        return response;
    }

    private async Task LogHttpResponseBody(HttpResponseMessage responseMessage, CancellationToken cancellationToken)
    {
        var bodyTask = responseMessage.Content.ReadAsStringAsync(cancellationToken);
        var body = await bodyTask;
        _logger.LogInformation("Telegram response: {Body}", body);
    }

    private async Task LogHttpRequestBody(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        var bodyTask = requestMessage.Content?.ReadAsStringAsync(cancellationToken);
        if (bodyTask is not null)
        {
            var body = await bodyTask;
            _logger.LogInformation("Telegram request: {Body}", body);
        }
    }
}