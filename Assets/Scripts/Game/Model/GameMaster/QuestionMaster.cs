using System;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;

namespace Scripts.Game.Model.GameMaster
{
    public sealed class QuestionMaster
    {
        public QuestionMaster(  PlayerMovementService playerMovementService,
                                GameBoardInfo gameBoard, 
                                QuestionService questionService,
                                RentPaymentMaster rentPaymentMaster    )
        {
            _playerMovementService = playerMovementService;
            _gameBoard = gameBoard;
            _questionService = questionService;
            _rentPaymentMaster = rentPaymentMaster;

            _playerMovementService.PlayerPositionChanged += PlayerPositionChangedHandler;
        }


        private PlayerMovementService _playerMovementService;
        private GameBoardInfo _gameBoard;
        private QuestionService _questionService;
        private RentPaymentMaster _rentPaymentMaster;

        private uint? _lastQuestionIndex = null;


        public event Action<uint> PlayerQuestionWasGenerated;


        private void PlayerPositionChangedHandler(PlayerInfo player, int playerID, uint? passedGameSquaresCount, uint newPlayerPosition)
        {
            GameSquareInfoBase gameSquareWherePlayerStands = _gameBoard.GameSquares[(int)newPlayerPosition];
            if(!DoesPlayerHaveToPayRent(player, gameSquareWherePlayerStands))
                return;
            
            int questionIndex = _questionService.GenerateQuestionForPlayerOnGameSquare(player);
            if(questionIndex == -1)
                return;
            
            _lastQuestionIndex = (uint)questionIndex;
            PlayerQuestionWasGenerated.Invoke((uint)_lastQuestionIndex);
        }

        private bool DoesPlayerHaveToPayRent(PlayerInfo player, GameSquareInfoBase gameSquareWherePlayerStands)
        {
            if(gameSquareWherePlayerStands is not OwnableSquare ownableSquareWherePlayerStands)
                return false;

            if(ownableSquareWherePlayerStands.Owner is null || ownableSquareWherePlayerStands.Owner == player)
                return false;

            return true;
        }
    
        public void PayRentForQuestion()
        {
            if(_questionService.IsRightAnswearOnQuestion((uint)_lastQuestionIndex))
                return;

            _rentPaymentMaster.PayRentByMakingTurnPlayer();
        }
    }
}