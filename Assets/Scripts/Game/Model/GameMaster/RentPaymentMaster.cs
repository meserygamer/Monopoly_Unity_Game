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
        public RentPaymentMaster(   PlayerMovementService playerMovementService,
                                    GameBoardInfo gameBoardInfo,
                                    BankingService bankingService,
                                    InfrastructureRentCostCalculatorService infrastructureRentCostCalculator,
                                    RailroadRentCostCalculatorService railroadRentCostCalculator,
                                    TangibleAssetRentCostCalculatorService tangibleAssetRentCostCalculator    )
        {
            _playerMovementService = playerMovementService;
            _gameBoardInfo = gameBoardInfo;
            _bankingService = bankingService;

            _rentCostCalculators = new Dictionary<Type, IRentCostCalculator>() 
            {
                { typeof(TangibleAssetSquare), tangibleAssetRentCostCalculator },
                { typeof(WaterStationGameSquare), infrastructureRentCostCalculator },
                { typeof(LightStationGameSquare), infrastructureRentCostCalculator },
                { typeof(RailRoadGameSquare), railroadRentCostCalculator }
            };

            _playerMovementService.PlayerPositionChanged += PlayerMovementService_PlayerPositionChanged;
        }


        private readonly PlayerMovementService _playerMovementService;
        private readonly GameBoardInfo _gameBoardInfo;
        private readonly BankingService _bankingService;

        private readonly Dictionary<Type, IRentCostCalculator> _rentCostCalculators;


        private void PlayerMovementService_PlayerPositionChanged(PlayerInfo player, int playerID, uint? passedGameSquaresCount, uint newPlayerPosition)
        {
            GameSquareInfoBase gameSquareWherePlayerStands = _gameBoardInfo.GameSquares[(int)newPlayerPosition];

            if(!DoesPlayerHaveToPayRent(player, gameSquareWherePlayerStands, out OwnableSquare ownableSquareWherePlayerStands))
                return;

            uint rentCost = CalculateCostOfRent(ownableSquareWherePlayerStands);

            _bankingService.TransferMoneyBetweenPlayers(player, ownableSquareWherePlayerStands.Owner, rentCost);
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