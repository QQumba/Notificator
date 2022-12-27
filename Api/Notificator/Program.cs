using System.Text.Json.Serialization;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;
using Notificator;
using Notificator.Data;
using Notificator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services, builder.Configuration);

var webApp = builder.Build();

ConfigureMiddleware(webApp, webApp.Environment, webApp.Configuration);
ConfigureEndpoints(webApp);

webApp.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers().AddJsonOptions(options =>
    {
        var stringEnumConverter = new JsonStringEnumConverter();
        options.JsonSerializerOptions.Converters.Add(stringEnumConverter);
    });
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddValidators();

    services.AddScoped<PublishService>();
    services.AddScoped<IConsumerService, ConsumerService>();
    services.AddNotificatorData(configuration);
}

void ConfigureMiddleware(IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
    allowedOrigins.ToList().ForEach(Console.WriteLine);
    app.UseCors(b => b.AllowAnyMethod().AllowAnyHeader().WithOrigins(allowedOrigins));

    app.UseHttpsRedirection();

    app.UseAuthorization();
}

void ConfigureEndpoints(IEndpointRouteBuilder app)
{
    app.MapControllers();
}