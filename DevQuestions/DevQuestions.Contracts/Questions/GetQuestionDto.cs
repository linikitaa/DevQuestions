namespace DevQuestion.Contracts.Questions;

public record GetQuestionDto(string Search, Guid[] TagIds, int PageSize);
