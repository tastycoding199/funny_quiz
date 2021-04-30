using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyQuiz.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public int QuestionNumber { get; set; }

        public string ContentQuestion { get; set; }

        public char CorrectAnswer { get; set; }

        public List<Answer> answers { get; set; }
    }
}
