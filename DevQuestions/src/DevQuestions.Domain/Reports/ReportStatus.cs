namespace DevQuestions.Domain.Reports;

public enum ReportStatus
{
    /// <summary>
    /// Статус открыт
    /// </summary>
    Open,

    /// <summary>
    /// Статус в работу
    /// </summary>
    InProgress,

    /// <summary>
    /// Стаутс решен
    /// </summary>
    Resolved,

    /// <summary>
    /// Статус закрыт
    /// </summary>
    Dismissed,
}
