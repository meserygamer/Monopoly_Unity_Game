using System;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;

namespace Scripts.Game.Model.GameMaster
{
    public sealed class QuestionMaster
    {
        public QuestionMaster(PlayerMovementService playerMovementService, GameBoardInfo gameBoard, QuestionService questionService)
        {
            _playerMovementService = playerMovementService;
            _gameBoard = gameBoard;
            _questionService = questionService;

            _playerMovementService.PlayerPositionChanged += PlayerMovementService_PlayerPositionChanged;
        }


        private PlayerMovementService _playerMovementService;
        private GameBoardInfo _gameBoard;
        private QuestionService _questionService;


        public event Action<uint> PlayerQuestionWasGenerated;


        private void PlayerMovementService_PlayerPositionChanged(PlayerInfo player, int playerID, uint? passedGameSquaresCount, uint newPlayerPosition)
        {
            GameSquareInfoBase gameSquareWherePlayerStands = _gameBoard.GameSquares[(int)newPlayerPosition];
            if(!DoesPlayerHaveToPayRent(player, gameSquareWherePlayerStands))
                return;
            
            int questionIndex = _questionService.GenerateQuestionForPlayerOnGameSquare(player);
            if(questionIndex == -1)
                return;
                
            PlayerQuestionWasGenerated.Invoke((uint)questionIndex);
        }

        private bool DoesPlayerHaveToPayRent(PlayerInfo player, GameSquareInfoBase gameSquareWherePlayerStands)
        {
            if(gameSquareWherePlayerStands is not OwnableSquare ownableSquareWherePlayerStands)
                return false;

            if(ownableSquareWherePlayerStands.Owner is null || ownableSquareWherePlayerStands.Owner == player)
                return false;

            return true;
        }
    }
}