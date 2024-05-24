using System.Collections.Generic;
using Scripts.Game.Model.Questions;

#nullable enable

namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Квадрат игрового поля с железной дорогой
    /// </summary>
    public class RailRoadGameSquare : OwnableSquare
    {
        public RailRoadGameSquare(string label, uint cost, List<QuestionSubtheme> subthemesInLine) : base(null, cost)
        {
            _label = label;
            _subthemesInLine = subthemesInLine;
        }


        private string _label;

        private List<QuestionSubtheme> _subthemesInLine = new List<QuestionSubtheme>();


        public override string Label => _label;

        public List<QuestionSubtheme> SubthemesInLine => _subthemesInLine;
    }
}