using Notificator.TelegramBot.Services;
using Notificator.TelegramBot.Util;
using Serilog;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

ConfigureLogging(builder, builder.Configuration);
ConfigureServices(builder.Services);

var webApp = builder.Build();

ConfigureMiddleware(webApp, webApp.Environment);
ConfigureEndpoints(webApp);

webApp.Run();

void ConfigureLogging(WebApplicationBuilder app, IConfiguration configuration)
{
    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

    app.Host.UseSerilog(logger);
}

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddHttpClient("telegram_bot_client")
        .AddTypedClient<ITelegramBotClient>((client, _) =>
        {
            const string token = "5628321676:AAHI1uqf2d-IjMsyAq5pFccqoLWImW425m8";
            var options = new TelegramBotClientOptions(token);
            return new TelegramBotClient(options, client);
        })
        .AddHttpMessageHandler(p => new LoggingMessageHandler(p));

    services.AddScoped<ReceiverService>();
    services.AddScoped<UpdateHandler>();
    services.AddHostedService<PollingService>();
}

void ConfigureMiddleware(IApplicationBuilder app, IHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
}

void ConfigureEndpoints(IEndpointRouteBuilder app)
{
    app.MapControllers();
}