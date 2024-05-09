using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services.CostOfRentServices
{
    public sealed class InfrastructureRentCostCalculatorService : IRentCostCalculator
    {
        public InfrastructureRentCostCalculatorService(DiceRollService diceRollService)
        {
            _diceRollService = diceRollService;
        }


        private readonly DiceRollService _diceRollService;

        private List<uint> _infarstructuRerentCostMultipliars = new List<uint>() {4, 10};


        public uint CalculateRentCost(OwnableSquare ownableSquare)
        {
            if(ownableSquare is not InfrastructureGameSquare tangibleAssetSquare)
                throw new ArgumentOutOfRangeException("OwnableSquare не является InfrastructureGameSquare");
            PlayerInfo gameSquareOwner = ownableSquare.Owner;
            DiceRoll diceRoll =  _diceRollService.SimulatePlayerRollDiceWithoutHistory();
            return diceRoll.SumCameUpNumbers * _infarstructuRerentCostMultipliars[CalculatePlayersInfrastructuresCount(gameSquareOwner) - 1];
        }

        private int CalculatePlayersInfrastructuresCount(PlayerInfo player) => player.BankAccount.GameSquaresInPossession.Count(a => a is InfrastructureGameSquare);
    }
}