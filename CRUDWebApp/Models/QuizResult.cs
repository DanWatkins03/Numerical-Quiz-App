namespace CRUDWebApp.Models
{
    public class QuizResult
    {
        public NumericalQuestions Question { get; set; }
        public string UserAnswer { get; set; } = "";
        public bool IsCorrect { get; set; }
    }
}
