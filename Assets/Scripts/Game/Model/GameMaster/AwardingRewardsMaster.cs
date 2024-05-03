using Scripts.Game.Model.GameField;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;

namespace Scripts.Game.Model.GameMaster
{
    public class AwardingRewardsMaster
    {
        public AwardingRewardsMaster(PlayerMovementService playerMovementService, BankingService bankingService)
        {
            _playerMovementService = playerMovementService;
            _bankingService = bankingService;
            _playerMovementService.PlayerPositionChanged += PlayerPositionChangedHandler;
        }

        
        ~AwardingRewardsMaster()
        {
            _playerMovementService.PlayerPositionChanged -= PlayerPositionChangedHandler;
        }


        private const uint CIRCLE_REWARD = 200;


        private PlayerMovementService _playerMovementService;
        private BankingService _bankingService;


        private void PlayerPositionChangedHandler(PlayerInfo player, int playerID, uint? passedGameSquaresCount, uint newPosition) => RewardForCompletingCircle(player, passedGameSquaresCount, newPosition);


        private void RewardForCompletingCircle(PlayerInfo player, uint? passedGameSquaresCount, uint newPosition)
        {
            if(passedGameSquaresCount is null)
                return;

            if ((int)newPosition - (int)passedGameSquaresCount < 0)
                _bankingService.GivePlayerMoney(player, CIRCLE_REWARD);
        }
    }
}