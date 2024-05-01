using Scripts.Game.Model.GameField;
using Scripts.Game.Services;

namespace Scripts.Game.Model.GameMaster
{
    public class AwardingRewardsMaster
    {
        public AwardingRewardsMaster(PlayerMovementService playerMovementService, BankingService bankingService, GameBoardInfo gameBoardInfo)
        {
            _playerMovementService = playerMovementService;
            _bankingService = bankingService;
            _gameBoardInfo = gameBoardInfo;
            _playerMovementService.PlayerPositionChanged += PlayerPositionChangedHandler;
        }

        
        ~AwardingRewardsMaster()
        {
            _playerMovementService.PlayerPositionChanged -= PlayerPositionChangedHandler;
        }


        private const uint CIRCLE_REWARD = 200;


        private PlayerMovementService _playerMovementService;
        private BankingService _bankingService;
        private GameBoardInfo _gameBoardInfo;


        private void PlayerPositionChangedHandler(int playerID, uint? oldPosition, uint newPosition) => RewardForCompletingCircle(playerID, oldPosition, newPosition);


        private void RewardForCompletingCircle(int playerID, uint? passedGameSquaresCount, uint newPosition)
        {
            if(passedGameSquaresCount is null)
                return;

            if ((int)newPosition - (int)passedGameSquaresCount < 0)
                _bankingService.GivePlayerMoney(playerID, CIRCLE_REWARD);
        }
    }
}