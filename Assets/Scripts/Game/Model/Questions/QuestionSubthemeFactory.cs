using System;
using Monopoly_Unity_Game_Server.Model;

namespace Scripts.Game.Model.Questions
{
    public class QuestionSubthemeFactory
    {
        public QuestionSubtheme GetQuestionSubtheme(QuestionTheme questionTheme, string subthemeTitle, Func<GameSquareExample> questionFactory)
        {
            QuestionSubtheme questionSubtheme = new QuestionSubtheme(subthemeTitle, questionTheme, questionFactory);
            questionTheme.Subthemes.Add(questionSubtheme);
            return questionSubtheme;
        }
    }
}