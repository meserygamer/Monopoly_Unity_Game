using Scripts.Game.Model.GameField.GameSquare;

namespace Scripts.Game.Services
{
    public sealed class ConstructionService
    {
        public void BuildBuildingNextLevel(TangibleAssetSquare gameSquareForConstruction) => gameSquareForConstruction.IncreaseAssetLevel();

        public void DemolishBuildingLevel(TangibleAssetSquare gameSquareForDemolishing) => gameSquareForDemolishing.DecreaseAssetLevel();
    }
}