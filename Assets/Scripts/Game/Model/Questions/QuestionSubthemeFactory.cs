namespace Scripts.Game.Model.Questions
{
    public class QuestionSubthemeFactory
    {
        public QuestionSubtheme GetQuestionSubtheme(QuestionTheme questionTheme, string subthemeTitle)
        {
            QuestionSubtheme questionSubtheme = new QuestionSubtheme(subthemeTitle, questionTheme);
            questionTheme.Subthemes.Add(questionSubtheme);
            return questionSubtheme;
        }
    }
}