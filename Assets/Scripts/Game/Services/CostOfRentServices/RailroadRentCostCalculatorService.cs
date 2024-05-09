using System;
using System.Linq;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services.CostOfRentServices
{
    public sealed class RailroadRentCostCalculatorService : IRentCostCalculator
    {
        private const uint STANDART_RAILROAD_RENT = 25; 


        public uint CalculateRentCost(OwnableSquare ownableSquare)
        {
            if(ownableSquare is not RailRoadGameSquare tangibleAssetSquare)
                throw new ArgumentOutOfRangeException("OwnableSquare не является RailRoadGameSquare");
            PlayerInfo GameSquareOwner = ownableSquare.Owner;
            return  Convert.ToUInt32(STANDART_RAILROAD_RENT * Math.Pow(2d, (double)CalculatePlayersRailRoadsCount(GameSquareOwner) - 1d));
        }

        private int CalculatePlayersRailRoadsCount(PlayerInfo player) => player.BankAccount.GameSquaresInPossession.Count(a => a is RailRoadGameSquare);
    }
}