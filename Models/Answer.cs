using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyQuiz.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public char Type { get; set; }

        public string contentAnswer { get; set; }

        public int QuestionId { get; set; }

        public Question question { get; set; }


    }
}
