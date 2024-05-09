using Scripts.Game.Model.GameField.GameSquare;

namespace Scripts.Game.Services.CostOfRentServices
{
    public interface IRentCostCalculator
    {
        uint CalculateRentCost(OwnableSquare ownableSquare);
    }
}