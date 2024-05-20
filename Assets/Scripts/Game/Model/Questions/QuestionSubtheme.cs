using System;
using Monopoly_Unity_Game_Server.Model;

namespace Scripts.Game.Model.Questions
{
    public class QuestionSubtheme
    {
        public QuestionSubtheme(string title, QuestionTheme questionTheme, Func<GameSquareExample> questionFactory)
        {
            Title = title;
            QuestionTheme = questionTheme;
            QuestionFactory = questionFactory;
        }


        public string Title { get; set; }

        public QuestionTheme QuestionTheme { get; }

        public Func<GameSquareExample> QuestionFactory { get; }
    }
}