using FluentValidation;
using RealTimeChatTask.BLL.DTOs;

namespace RealTimeChatTask.BLL.Validators;

public class MessageValidator : AbstractValidator<MessageDTO>
{
    public MessageValidator()
    {
        RuleFor(message => message.Content)
            .NotEmpty().WithMessage("Content cannot be empty.")
            .MaximumLength(100).WithMessage("Content must not exceed one hundred characters.");

        RuleFor(message => message.CreationDate)
            .Must(date => date <= DateTime.UtcNow).WithMessage("CreationDate must be a valid date.");
    }
}