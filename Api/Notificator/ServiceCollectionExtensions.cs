using FluentValidation;
using Notificator.DataTransfer;
using Notificator.Validators;

namespace Notificator;

public static class ServiceCollectionExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<MessageCreateDto>, MessageValidator>();
    }
}