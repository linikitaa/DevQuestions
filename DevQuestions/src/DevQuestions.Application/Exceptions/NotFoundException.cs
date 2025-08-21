using Shared;

namespace DevQuestions.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(Error[] errors) : base()
    {
    }
}
