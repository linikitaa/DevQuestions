using DevQuestions.Domain.Questions;

namespace DevQuestions.Application.Questions;

public interface IQuestionsRepository
{
    Task<Guid> AddAsync(Question question, CancellationToken cancellationToken);
    
    Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken);
    
    Task<Guid> DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Question> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken);
}
