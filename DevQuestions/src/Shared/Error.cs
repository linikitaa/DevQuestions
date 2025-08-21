namespace Shared;

public record Error
{
    public string Code { get; }
    public string Message { get; }
    public ErrorType Type { get; }
    public string? InvalidField { get; }

    public Error(string code, string message, ErrorType type, string? invalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidField = invalidField;
    }
    
    public static Error NotFound(string message, Guid id)=> new("record.not.found", message, ErrorType.NOT_FOUND);
    public static Error Validation(string message, string InvalidField)=> new("record.is.invalid", message, ErrorType.VALIDATION);
    public static Error Conflict(string? code, string message) => new(code ?? "value.is.conflict", message, ErrorType.CONFLICT);
    public static Error FAILURE(string? code, string message) => new(code ?? "value.is.FAILURE", message, ErrorType.FAILURE);
}

public enum ErrorType
{
    VALIDATION,
    NOT_FOUND,
    FAILURE,
    CONFLICT
}
