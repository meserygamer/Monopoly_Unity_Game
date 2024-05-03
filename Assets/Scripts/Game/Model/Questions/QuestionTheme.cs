using System.Collections.Generic;

namespace Scripts.Game.Model.Questions
{
    public class QuestionTheme
    {
        public QuestionTheme(string title)
        {
            Title = title;
        }


        public string Title { get; set; }

        public List<QuestionSubtheme> Subthemes { get; } = new List<QuestionSubtheme>();
    }
}