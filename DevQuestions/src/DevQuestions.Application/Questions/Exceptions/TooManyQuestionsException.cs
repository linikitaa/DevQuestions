using Shared;

namespace DevQuestions.Application.Questions.Exceptions;

public class TooManyQuestionsException : Exception
{
    public TooManyQuestionsException(Error[] errors)
    {
        
    }
}
