using Notificator.DataTransfer;

namespace Notificator.Services;

public class WebhookService
{
    private readonly HashSet<string> _subscribers = new();

    private readonly HttpClient _client;

    public WebhookService(HttpClient client)
    {
        _client = client;
    }

    public IEnumerable<string> Subscribers => _subscribers;

    public bool Subscribe(string callbackUrl)
    {
        var callbackRegistered = _subscribers.Add(callbackUrl);
        return callbackRegistered;
    }

    public bool Unsubscribe(string callbackUrl)
    {
        var callbackRemoved = _subscribers.Remove(callbackUrl);
        return callbackRemoved;
    }

    public async Task<WebhookMessagingResult> NotifyAll<T>(T payload)
    {
        var failedCallbacks = new List<string>();
        
        foreach (var callbackUrl in _subscribers)
        {
            var response = await _client.PostAsJsonAsync(callbackUrl, payload);
            if (!response.IsSuccessStatusCode)
            {
                failedCallbacks.Add(callbackUrl);
            }
        }

        var result = new WebhookMessagingResult
        {
            Total = _subscribers.Count,
            Failed = failedCallbacks.Count
        };

        return result;
    }
}