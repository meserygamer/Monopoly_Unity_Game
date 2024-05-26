#nullable enable

using System;
using System.Collections.Generic;
using Monopoly_Unity_Game_Server.Model;
using Scripts.Game.Model.Questions;

namespace Scripts.Game.Model.GameField.GameSquare
{
    public class InfrastructureGameSquare : OwnableSquare
    {
        public InfrastructureGameSquare(string label, uint cost, List<QuestionSubtheme> questionSubthemesOnBoard) : base(null, cost)
        {
            _label = label;
            QuestionSubthemesOnBoard = questionSubthemesOnBoard;
        }


        private string _label;


        public override string Label => _label; 

        /// <summary>
        /// Нужен для генерации вопросов при окончании хода на клетке
        /// </summary>
        public List<QuestionSubtheme> QuestionSubthemesOnBoard { get; }


        public override GameSquareExample GetGameSquareExample() => 
            QuestionSubthemesOnBoard[new Random().Next(0, QuestionSubthemesOnBoard.Count)].QuestionFactory.Invoke();
    }
}