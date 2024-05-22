using System;
using System.Collections.Generic;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;
using Scripts.Game.Services.CostOfRentServices;

namespace Scripts.Game.Model.GameMaster
{
    public sealed class RentPaymentMaster
    {
        public RentPaymentMaster(   GameBoardInfo gameBoardInfo,
                                    BankingService bankingService,
                                    PlayerMovementService playerMovementService,
                                    PlayersMovesTurnService playersMovesTurnService,
                                    InfrastructureRentCostCalculatorService infrastructureRentCostCalculator,
                                    RailroadRentCostCalculatorService railroadRentCostCalculator,
                                    TangibleAssetRentCostCalculatorService tangibleAssetRentCostCalculator    )
        {
            _gameBoardInfo = gameBoardInfo;
            _bankingService = bankingService;
            _playerMovementService = playerMovementService;
            _playersMovesTurnService = playersMovesTurnService;

            _rentCostCalculators = new Dictionary<Type, IRentCostCalculator>() 
            {
                { typeof(TangibleAssetSquare), tangibleAssetRentCostCalculator },
                { typeof(WaterStationGameSquare), infrastructureRentCostCalculator },
                { typeof(LightStationGameSquare), infrastructureRentCostCalculator },
                { typeof(RailRoadGameSquare), railroadRentCostCalculator }
            };
        }


        private readonly GameBoardInfo _gameBoardInfo;
        private readonly BankingService _bankingService;
        private readonly PlayerMovementService _playerMovementService;
        private readonly PlayersMovesTurnService _playersMovesTurnService;

        private readonly Dictionary<Type, IRentCostCalculator> _rentCostCalculators;


        public void PayRentByMakingTurnPlayer()
        {
            int? playerPosition = (int?)_playerMovementService.GetPlayerPosition(_playersMovesTurnService.MakingTurnPlayer);

            if(playerPosition is null)
                throw new ArgumentException("Игрок делающий ход отсутсвует на игровом поле");

            GameSquareInfoBase gameSquareWherePlayerStands = _gameBoardInfo.GameSquares[(int)playerPosition];

            if(!DoesPlayerHaveToPayRent(_playersMovesTurnService.MakingTurnPlayer, gameSquareWherePlayerStands, out OwnableSquare ownableSquareWherePlayerStands))
                return;

            uint rentCost = CalculateCostOfRent(ownableSquareWherePlayerStands);

            _bankingService.TransferMoneyBetweenPlayers(_playersMovesTurnService.MakingTurnPlayer, ownableSquareWherePlayerStands.Owner, rentCost);
        }

        private bool DoesPlayerHaveToPayRent(PlayerInfo player, GameSquareInfoBase gameSquareWherePlayerStands, out OwnableSquare ownableSquare)
        {
            ownableSquare = null;

            if(gameSquareWherePlayerStands is not OwnableSquare ownableSquareWherePlayerStands)
                return false;

            ownableSquare = ownableSquareWherePlayerStands;

            if(ownableSquareWherePlayerStands.Owner is null || ownableSquareWherePlayerStands.Owner == player)
                return false;

            return true;
        }

        private uint CalculateCostOfRent(OwnableSquare ownableSquare) => _rentCostCalculators[ownableSquare.GetType()].CalculateRentCost(ownableSquare);
    }
}