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


        public bool BuySquare(PlayerInfo player, OwnableSquare ownableSquare)
        {
            if(player is null || ownableSquare is null)
                return false;
            
            if(!_bankingService.TakePlayerMoneyIfEnought(player, ownableSquare.Cost))
                return false;
            
            ownableSquare.ChangeOwner(player);
            return true;
        }
    }
}