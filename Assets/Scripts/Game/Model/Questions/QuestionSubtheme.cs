namespace Scripts.Game.Model.Questions
{
    public class QuestionSubtheme
    {
        public QuestionSubtheme(string title, QuestionTheme questionTheme)
        {
            Title = title;
            QuestionTheme = questionTheme;
        }


        public string Title { get; set; }

        public QuestionTheme QuestionTheme { get; }
    }
}