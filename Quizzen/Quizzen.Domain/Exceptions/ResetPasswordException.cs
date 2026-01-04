namespace Quizzen.Domain.Exceptions
{
    public class ResetPasswordException(IEnumerable<string> errorDescriptions) : Exception($"Reset password failed with following errors: ${string.Join(Environment.NewLine, errorDescriptions)}");
}
