namespace Quizzen.Application.Abstracts
{
    public interface IOTPGenerator
    {
        public string Generate(int length = 6);
    }
}
