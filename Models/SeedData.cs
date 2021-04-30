using FunnyQuiz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyQuiz.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new QuizContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<QuizContext>>()))
            {

                //List<Question> questions = new List<Question>() { 
                //    new Question()
                //    {
                //        ContentQuestion="In a forest,There are a Horse and a Turtle.That day,A turtle went to the Horse place and asked him for a trip together. Where were they going to go.",
                //        CorrectAnswer='B',
                //        QuestionNumber=1
                //    },
                //    new Question()
                //    {
                //        ContentQuestion="In a Circus,There are many deaf elephants. How many elephant in that circus.",
                //        CorrectAnswer='D',
                //        QuestionNumber=2,
                //    },

                //    new Question()
                //    {
                //        ContentQuestion="On a branch of a tall tree,There is a bird then 'three bird' flew ahead and stood on the branch and then 'many bird' flew ahead and stood on the branch. How many bird on the branch.",
                //        CorrectAnswer='A',
                //        QuestionNumber=3
                //    }
                //};

                //foreach (var item in questions)
                //{
                //    context.questions.Add(item);
                //}


                List<Answer> answers = new List<Answer>()
                {
                    new Answer() {Type='A',QuestionId=1,contentAnswer="Canada."},
                    new Answer() {Type='B',QuestionId=1,contentAnswer="US."},
                    new Answer() {Type='C',QuestionId=1,contentAnswer="VietNam."},
                    new Answer() {Type='D',QuestionId=1,contentAnswer="Wherever."},

                    new Answer() {Type='A',QuestionId=2,contentAnswer="10."},
                    new Answer() {Type='B',QuestionId=2,contentAnswer="1."},
                    new Answer() {Type='C',QuestionId=2,contentAnswer="0."},
                    new Answer() {Type='D',QuestionId=2,contentAnswer="24."},

                    new Answer() {Type='A',QuestionId=3,contentAnswer="3."},
                    new Answer() {Type='B',QuestionId=3,contentAnswer="1."},
                    new Answer() {Type='C',QuestionId=3,contentAnswer="0."},
                    new Answer() {Type='D',QuestionId=3,contentAnswer="Many birds."},
                };

                foreach (var item in answers)
                {
                    context.answers.Add(item);
                }
                context.SaveChanges();


            }
        }
    }
}
