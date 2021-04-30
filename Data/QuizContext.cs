using FunnyQuiz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyQuiz.Data
{
    public class QuizContext:DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasKey(k => k.QuestionId);

            modelBuilder.Entity<Question>()
               .Property(p => p.ContentQuestion).IsRequired();

            modelBuilder.Entity<Question>()
                .Property(p => p.ContentQuestion).HasMaxLength(200);

            modelBuilder.Entity<Question>().Property(p => p.CorrectAnswer).IsRequired();

            modelBuilder.Entity<Question>().Property(p => p.CorrectAnswer).HasMaxLength(1);


            //--------------------------------------------------------------

            modelBuilder.Entity<Answer>().HasKey(k => k.AnswerId);

            modelBuilder.Entity<Answer>()
               .Property(p => p.contentAnswer).IsRequired();

            modelBuilder.Entity<Answer>()
                .Property(p => p.contentAnswer).HasMaxLength(50);

            modelBuilder.Entity<Answer>().Property(p => p.Type).IsRequired();

            modelBuilder.Entity<Answer>().Property(p => p.Type).HasMaxLength(1);

        }

        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }
    }
}
