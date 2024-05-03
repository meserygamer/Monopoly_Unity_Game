using System;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;

#nullable enable

namespace Scripts.Game.Model.GameMaster
{
    public class RealEstateBuyingMaster
    {
        public RealEstateBuyingMaster(PlayerMovementService playerMovementService,
                                      PlayersMovesTurnService playersMovesTurnService, 
                                      GameBoardInfo gameBoardInfo, 
                                      RealEstatePurchaseService realEstatePurchaseService)
        {
            _playerMovementService = playerMovementService;
            _playersMovesTurnService = playersMovesTurnService;
            _gameBoardInfo = gameBoardInfo;
            _realEstatePurchaseService = realEstatePurchaseService;
            _playerMovementService.PlayerPositionChanged += PlayerPositionChangedHandler;
        }

        
        private PlayerMovementService _playerMovementService;
        private PlayersMovesTurnService _playersMovesTurnService;
        private GameBoardInfo _gameBoardInfo;
        private RealEstatePurchaseService _realEstatePurchaseService;


        public event Action<OwnableSquare> MakingTurnPlayerCanBuySquare;


        public bool IsMarkingTurnPlayerCanBuySquare { get; set; } = false;


        private void PlayerPositionChangedHandler(PlayerInfo player, int playerID, uint? passedGameSquaresCount, uint newPosition)
        {
            GameSquareBase gameSquare = _gameBoardInfo.GameSquares[Convert.ToInt32(newPosition)];
            if(CanGameSquareBeBought(gameSquare) && CanPlayerBuyGameSquare(_playersMovesTurnService.MakingTurnPlayer, (OwnableSquare)gameSquare))
            {
                IsMarkingTurnPlayerCanBuySquare = true;
                MakingTurnPlayerCanBuySquare?.Invoke((OwnableSquare)gameSquare);
                return;
            }
            IsMarkingTurnPlayerCanBuySquare = false;
        }


        private bool CanGameSquareBeBought(GameSquareBase gameSquare)
        {
            if(gameSquare is OwnableSquare ownableSquare && ownableSquare.Owner is null)
                return true;
            return false;
        }

        private bool CanPlayerBuyGameSquare(PlayerInfo playerInfo, OwnableSquare ownableSquare)
        {
            if(ownableSquare.Cost > playerInfo.BankAccount.MoneyAmount)
                return false;
            return true;
        }

        public void BuyGameSquareByMakingTurnPlayer()
        {
            if(!IsMarkingTurnPlayerCanBuySquare)
                return;
            PlayerInfo player = _playersMovesTurnService.MakingTurnPlayer;
            uint? playerPosition = _playerMovementService.GetPlayerPosition(player);
            if(playerPosition is null)
                throw new ArgumentOutOfRangeException("Пользователя покупающего недвижимость несуществует на игровой доске");
            OwnableSquare? ownableSquare = _gameBoardInfo.GameSquares[Convert.ToInt32((uint)playerPosition)] as OwnableSquare;
            if(ownableSquare is null)
                throw new ArgumentOutOfRangeException("Покупаемое поле недоступно для покупки");
            _realEstatePurchaseService.BuySquare(player, ownableSquare);
        }
    }
}