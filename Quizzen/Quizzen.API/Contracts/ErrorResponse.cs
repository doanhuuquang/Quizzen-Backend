namespace Quizzen.API.Contracts
{
    public record ErrorResponse
    (
        int StatusCode,
        string Error,
        string Message,
        DateTime Timestamp
    );
}
