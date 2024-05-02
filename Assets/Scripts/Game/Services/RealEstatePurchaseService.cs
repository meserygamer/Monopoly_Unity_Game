using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public class RealEstatePurchaseService 
    {
        public RealEstatePurchaseService(BankingService bankingService)
        {
            _bankingService = bankingService;
        }


        private BankingService _bankingService;


        public void BuyTangibleAsset(PlayerInfo playerInfo, TangibleAssetSquare tangibleAssetSquare)
        {
            if(playerInfo is null || tangibleAssetSquare is null)
                return;
            

        }
    }
}