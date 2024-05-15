using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public sealed class ConstructionService
    {
        public ConstructionService(BankingService bankingService)
        {
            _bankingService = bankingService;
        } 


        private BankingService _bankingService;


        public void BuildBuildingNextLevel(TangibleAssetSquare gameSquareForConstruction) 
        {
            if(gameSquareForConstruction.IncreaseAssetLevel())
            {
                _bankingService.TakePlayerMoney(gameSquareForConstruction.Owner, gameSquareForConstruction.ConstructionCosts[0]);
            }
        }

        public void DemolishBuildingLevel(TangibleAssetSquare gameSquareForDemolishing) => gameSquareForDemolishing.DecreaseAssetLevel();

        public bool CheckWhetherUserCanPurchaseNewBuildingLevel(OwnableSquare gameSquare, PlayerInfo buyer)
        {
            if(!DoesGameSquareBelongToPlayer(gameSquare, buyer))
                return false;

            if(!_bankingService.CanPlayerPayBill(buyer, gameSquare.Cost))
                return false;

            return true;
        } 

        private bool DoesGameSquareBelongToPlayer(OwnableSquare gameSquare, PlayerInfo buyer) => gameSquare.Owner == buyer;
    }
}