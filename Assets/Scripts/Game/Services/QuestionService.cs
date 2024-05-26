using System;
using System.Collections.Generic;
using System.Text;
using Monopoly_Unity_Game_Server.Model;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public class QuestionService
    {
        public QuestionService(PlayerMovementService playerMovementService, GameBoardInfo gameBoardInfo)
        {
            _playerMovementService = playerMovementService;
            _gameBoardInfo = gameBoardInfo;
        }


        private PlayerMovementService _playerMovementService;
        private GameBoardInfo _gameBoardInfo;

        private List<(PlayerInfo, GameSquareExample, string)> _questionHistory = new List<(PlayerInfo, GameSquareExample, string)>();


        /// <summary>
        /// Функция генерации вопроса для игрока по его позиции на поле
        /// </summary>
        /// <param name="player">игрок</param>
        /// <returns>-1 - если для игрока нельзя сгенерировать вопрос или индекс вопроса</returns>
        public int GenerateQuestionForPlayerOnGameSquare(PlayerInfo player)
        {
            uint? playerPosition = _playerMovementService.GetPlayerPosition(player);
            if(playerPosition is null)
                throw new ArgumentException("Игрока несуществует");

            OwnableSquare playersPlacement = _gameBoardInfo.GameSquares[(int)playerPosition] as OwnableSquare;
            if(playersPlacement is null)
                return -1;

            int questionIndex = _questionHistory.Count;
            _questionHistory.Add(new (player, playersPlacement.GetGameSquareExample(), null));
            return questionIndex;
        }

        public GameSquareExample GetGameSquareExample(uint questionIndex)
        {
            if(questionIndex >= _questionHistory.Count)
                throw new ArgumentOutOfRangeException("Вопрос с таким индексом не был сгенерирован");
            
            return _questionHistory[(int)questionIndex].Item2;
        }

        public bool GiveAnswearToQuestion(uint questionIndex, string playerAnswear)
        {
            GameSquareExample gameSquareExample = GetGameSquareExample(questionIndex);

            playerAnswear = playerAnswear.Trim().Replace('.',',');
            (PlayerInfo, GameSquareExample, string) question = _questionHistory[(int)questionIndex];
            question.Item3 = playerAnswear;
            _questionHistory[(int)questionIndex] = question;

            string rightAnswear = FormRightAnswear(gameSquareExample);
            if(playerAnswear == rightAnswear)
                return true;
            return false;
        }

        public string GetRightAnswearOnQuestion(uint questionIndex)
        {
            GameSquareExample gameSquareExample = GetGameSquareExample(questionIndex);
            return FormRightAnswear(gameSquareExample);
        }

        public bool IsRightAnswearOnQuestion(uint questionIndex)
        {
            if(questionIndex >= _questionHistory.Count)
                throw new ArgumentException("Вопроса с таким индексом несуществует");
            
            if(_questionHistory[(int)questionIndex].Item3 is null)
                return false;

            if(FormRightAnswear(GetGameSquareExample(questionIndex)) == _questionHistory[(int)questionIndex].Item3)
                return true;
            return false;
        }

        private string FormRightAnswear(GameSquareExample gameSquareExample)
        {
            StringBuilder rightAnswearBuilder = new StringBuilder("");
            foreach(var answear in gameSquareExample.Question.Answers)
            {
                if(rightAnswearBuilder.Length > 0)
                    rightAnswearBuilder.Append("; ");
                rightAnswearBuilder.Append(answear.ToString().Trim());
            }
            return rightAnswearBuilder.Replace('.', ',').ToString();
        }
    }
}