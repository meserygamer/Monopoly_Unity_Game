using System;
using Scripts.Game.Model.GameField.GameSquare;

namespace Scripts.Game.Services.CostOfRentServices
{
    public sealed class TangibleAssetRentCostCalculatorService : IRentCostCalculator
    {
        public uint CalculateRentCost(OwnableSquare ownableSquare)
        {
            if(ownableSquare is not TangibleAssetSquare tangibleAssetSquare)
                throw new ArgumentOutOfRangeException("OwnableSquare не является TangibleAssetSquare");
            return tangibleAssetSquare.RentalCosts[tangibleAssetSquare.AssetLevel];
        }
    }
}