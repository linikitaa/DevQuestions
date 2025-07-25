namespace DevQuestion.Contarcts;

public record CreateQuestionDto(string Title, string Body, Guid UserId, Guid[] TagIds);
