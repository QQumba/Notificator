namespace Notificator.Data.Clients;

public interface IWebhookClient
{
    public Task NotifyAsync(string url, HttpContent content);
}

public class WebhookClient : IWebhookClient
{
    private readonly HttpClient _client;


    public WebhookClient(HttpClient client)
    {
        _client = client;
    }

    public async Task NotifyAsync(string url, HttpContent content)
    {
        await _client.PostAsync(url, content);
    }
}