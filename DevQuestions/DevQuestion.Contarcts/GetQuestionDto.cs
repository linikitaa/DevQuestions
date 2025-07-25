namespace DevQuestion.Contarcts;

public record GetQuestionDto(string Search, Guid[] TagIds, int PageSize);
