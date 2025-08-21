using DevQuestion.Contracts.Questions;

namespace DevQuestions.Application;

public interface IQuestionsService
{
    Task<Guid> Create( CreateQuestionDto questionDto, CancellationToken cancellationToken);
}
