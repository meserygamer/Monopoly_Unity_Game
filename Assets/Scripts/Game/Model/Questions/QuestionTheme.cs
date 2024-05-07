using System;
using System.Collections.Generic;

namespace Scripts.Game.Model.Questions
{
    public class QuestionTheme
    {
        public QuestionTheme(string title, uint themeID)
        {
            Title = title;
            ThemeID = themeID;
        }


        public uint ThemeID { get; }

        public string Title { get; set; }

        public List<QuestionSubtheme> Subthemes { get; } = new List<QuestionSubtheme>();
    }
}