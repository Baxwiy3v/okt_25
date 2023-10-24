using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp231231.Models
{
    internal class Quiz
    {
        private string quizName;

        public int Id { get; }
        public string Name { get; }
        public List<Question> Questions { get; }

        public Quiz(int id, string name, List<Question> questions)
        {
            Id = id;
            Name = name;
            Questions = questions;
        }

        public Quiz(string quizName, List<Question> questions)
        {
            this.quizName = quizName;
            Questions = questions;
        }
    }
}


