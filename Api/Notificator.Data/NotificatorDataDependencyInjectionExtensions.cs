using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notificator.Data.Clients;
using Notificator.Data.Services;
using Telegram.Bot;

namespace Notificator.Data;

public static class NotificatorDataDependencyInjectionExtensions
{
    public static void AddNotificatorData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IWebhookClient, WebhookClient>();
        services.AddHttpClient<ITelegramBotClient, TelegramBotClient>(client =>
        {
            var token = configuration.GetSection("Telegram:Token").Value;
            var options = new TelegramBotClientOptions(token);
            return new TelegramBotClient(options, client);
        });

        services.AddDbContext<NotificatorDbContext>(options => options
            .UseNpgsql(configuration.GetConnectionString("Npgsql"))
            .UseSnakeCaseNamingConvention()
        );

        services.AddScoped<WebhookPublishHandler>();
        services.AddScoped<EmailPublishHandler>();
        services.AddScoped<TelegramPublishHandler>();
    }
}