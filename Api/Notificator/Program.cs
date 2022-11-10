using Notificator;
using Notificator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddHttpClient<WebhookService>();
    services.AddSingleton<WebhookService>();
    services.AddValidators();
}