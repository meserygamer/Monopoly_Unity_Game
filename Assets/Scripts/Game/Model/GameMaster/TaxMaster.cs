using System;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;

namespace Scripts.Game.Model.GameMaster
{
    public class TaxMaster
    {
        public TaxMaster(PlayerMovementService playerMovementService, BankingService bankingService, GameBoardInfo gameBoardInfo)
        {
            _playerMovementService = playerMovementService;
            _bankingService = bankingService;
            _gameBoardInfo = gameBoardInfo;

            _playerMovementService.PlayerPositionChanged += PlayerPositionChangedHandler;
        }


        private readonly PlayerMovementService _playerMovementService;
        private readonly BankingService _bankingService;
        private readonly GameBoardInfo _gameBoardInfo;


        private void PlayerPositionChangedHandler(PlayerInfo player, int playerID, uint? passedGameSquaresCount, uint newPlayerPosition)
        {
            TaxGameSquare gameSquare = _gameBoardInfo.GameSquares[(int)newPlayerPosition] as TaxGameSquare;

            if(gameSquare is null)
                return;
            
            _bankingService.TakePlayerMoney(player, gameSquare.AmountOfTax);
        }
    }
}
