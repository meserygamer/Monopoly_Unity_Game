#nullable enable

using System.Collections.Generic;
using Scripts.Game.Model.Questions;

namespace Scripts.Game.Model.GameField.GameSquare
{
    public class WaterStationGameSquare : InfrastructureGameSquare
    {
        public WaterStationGameSquare(string label, uint cost, List<QuestionSubtheme> questionSubthemesOnBoard) : base(label, cost, questionSubthemesOnBoard) {}
    }
}