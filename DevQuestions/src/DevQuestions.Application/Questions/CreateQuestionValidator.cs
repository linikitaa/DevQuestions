using DevQuestion.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(q => q.Title).NotEmpty().MaximumLength(500).WithMessage("Заголовок невалидный");
        RuleFor(q => q.Text).NotEmpty().MaximumLength(5000).WithMessage("Текст невалидный");
        RuleFor(q => q.UserId).NotEmpty();
    }
}
