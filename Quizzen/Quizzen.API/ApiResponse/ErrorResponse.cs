namespace Quizzen.API.ApiResponse
{
    public record ErrorResponse
    (
        int StatusCode,
        string Error,
        string Message,
        DateTime Timestamp
    );
}
