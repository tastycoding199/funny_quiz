using FunnyQuiz.Data;
using FunnyQuiz.DTO;
using FunnyQuiz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyQuiz.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizContext Db;
        public QuizController(QuizContext Db)
        {
            this.Db = Db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Wrong()
        {
            return View();
        }



        public async Task<IActionResult> Game(int? id)
        {
            int currentQuestion = id.GetValueOrDefault() <= 0 ? 1 : id.Value;

            Question question = await Db.questions.Include(p => p.answers).AsNoTracking().FirstOrDefaultAsync(p => p.QuestionNumber == currentQuestion);

            if (question == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimeOut"] = 30;

            return View(question);
        }



        [HttpPost]
        public async Task<IActionResult> CheckAnswer(int QuestionId, char AnswerType)
        {
            Question question = await Db.questions.Include(p => p.answers).AsNoTracking().FirstOrDefaultAsync(p => p.QuestionNumber == QuestionId);

            if (AnswerType.CompareTo(question.CorrectAnswer) == 0)
            {
                return RedirectToAction(nameof(Game), new { id = (question.QuestionNumber + 1) });
            }

            return RedirectToAction(nameof(Wrong));
        }


    }
}
