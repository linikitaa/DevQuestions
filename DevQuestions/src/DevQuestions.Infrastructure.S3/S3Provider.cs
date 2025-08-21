using DevQuestions.Application.FilesStorage;

namespace DevQuestions.Infrastructure.S3;

public class S3Provider : IFilesProvider
{
    public Task<string> UploadAsync(Stream fileStream, string fileName)
    {
        throw new NotImplementedException();
    }
}
