using DevQuestion.Contracts.Questions;
using DevQuestions.Application.Questions;
using DevQuestions.Application.Questions.Exceptions;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DevQuestions.Application;

public class QuestionsService : IQuestionsService
{

    private readonly IQuestionsRepository _questionsRepository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public QuestionsService(IQuestionsRepository questionsRepository, ILogger<QuestionsService> logger, IValidator<CreateQuestionDto> validator)
    {
        _questionsRepository = questionsRepository;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Guid> Create( CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new TooManyQuestionsException([Error.FAILURE("questions.too.many", "Too many questions")]);
        }
        
        // валидация бизнес логики
        
        var openUserQuestionsCount = await _questionsRepository.GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);
        if (openUserQuestionsCount > 3)
        {
            throw new Exception("Пользователь не может открыть больше 3 вопросов");
        }
         
        // Создание сущности Question
        var questionId = Guid.NewGuid();
        var question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds.ToList()
        );
        // Сохранение сущности Question в бд
        await _questionsRepository.AddAsync(question, cancellationToken);
        
        // Логирование об успешном или неуспешном сохранение
        _logger.LogInformation("Questions created with id {questionId}", questionId);
        return questionId;
    }

    /*
    public async Task<IActionResult> Update([FromRoute] Guid questionId, UpdateQuestionDto request, CancellationToken cancellationToken)
    {
    }
    
    public async Task<IActionResult> Delete([FromRoute] Guid questionId, CancellationToken cancellationToken)
    {
    }
    
    public async Task<IActionResult> SelectSolution([FromRoute] Guid questionId, [FromQuery] Guid answerId, CancellationToken cancellationToken)
    {
    }
    
    public async Task<IActionResult> AddAnswer([FromRoute] Guid questionId, AddAnswerDto request, CancellationToken cancellationToken)
    {
    }
    */
}
