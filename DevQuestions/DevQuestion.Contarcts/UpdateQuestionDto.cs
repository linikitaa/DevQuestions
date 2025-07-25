namespace DevQuestion.Contarcts;

public record UpdateQuestionDto(string Title, string Body, Guid[] TagIds);
