using CRUDWebApp.Data;
using CRUDWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Quiz
        public async Task<IActionResult> Index()
        {
            var questions = await _context.NumericalQuestions
                .OrderBy(q => Guid.NewGuid())
                .Take(5)
                .ToListAsync();

            return View(questions);
        }

        // POST: /Quiz/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(int[] questionIds, string[] userAnswers)
        {
            var questions = await _context.NumericalQuestions
                .Where(q => questionIds.Contains(q.Id))
                .ToListAsync();

            var results = new List<QuizResult>();

            for (int i = 0; i < questionIds.Length; i++)
            {
                var question = questions.FirstOrDefault(q => q.Id == questionIds[i]);

                if (question == null)
                {
                    continue;
                }

                var userAnswer = userAnswers[i] ?? "";

                bool isCorrect = Normalize(userAnswer) == Normalize(question.NumericalAnswer);

                results.Add(new QuizResult
                {
                    Question = question,
                    UserAnswer = userAnswer,
                    IsCorrect = isCorrect
                });
            }

            return View("Result", results);
        }

        private string Normalize(string value)
        {
            return value
                .Trim()
                .ToLower()
                .Replace("£", "")
                .Replace("%", "")
                .Replace(" ", "");
        }
    }
}