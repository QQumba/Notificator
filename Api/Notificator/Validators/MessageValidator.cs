using FluentValidation;
using Notificator.DataTransfer;

namespace Notificator.Validators;

public class MessageValidator : AbstractValidator<MessageCreateDto>
{
    public MessageValidator()
    {
        RuleFor(m => m.Payload.Length).Must(m => m >= 3)
            .WithMessage($"Minimum length of {nameof(MessageCreateDto.Payload)} should be 3 or greater.");
    }
}