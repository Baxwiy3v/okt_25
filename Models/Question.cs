using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp231231.Models
{
    internal class Question
    {
        private string questionText;

        public int Id { get; }
        public string Text { get; }
        public List<string> AnswerOptions { get; }
        public int CorrectAnswerIndex { get; }

        public Question(int id, string text, List<string> answerOptions, int correctAnswerIndex)
        {
            Id = id;
            Text = text;
            AnswerOptions = answerOptions;
            CorrectAnswerIndex = correctAnswerIndex;
        }

        public Question(string questionText, List<string> answerOptions, int correctAnswerIndex)
        {
            this.questionText = questionText;
            AnswerOptions = answerOptions;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}

