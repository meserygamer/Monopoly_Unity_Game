using Scripts.Game.Model.Player;
using Scripts.Game.Services;
using Scripts.Game.View;

namespace Scripts.Game.Presenter
{
    public sealed class PlayerPositionShowerPresenter
    {
        public PlayerPositionShowerPresenter(PlayerMovementService playerMovementService)
        {
            _playerMovementService = playerMovementService;
            _playerMovementService.PlayerPositionChanged += PlayerPositionChangedHandler;
            UpdatePlayersPositions();
        }


        ~PlayerPositionShowerPresenter()
        {
            _playerMovementService.PlayerPositionChanged -= PlayerPositionChangedHandler;
        }


        private readonly PlayerMovementService _playerMovementService;


        public PlayerPositionShower? View { get; set; } = null;


        private void UpdatePlayersPositions()
        {
            for(int i = 0; i < _playerMovementService.PlayersPositions.Count; i++)
            {
                View?.MovePlayersPawn(i, _playerMovementService.PlayersPositions[i].PositionOnGameBoard);
            }
        }

        private void PlayerPositionChangedHandler(PlayerInfo playerInfo, int playerID, uint? passedGameSquaresCount, uint newPosition) 
        {
            if(_playerMovementService.GameBoardJail.IsPlayerInJail(playerInfo))
                View?.MovePlayerIntoJail(playerID, newPosition);
            else
                View?.MovePlayersPawn(playerID, newPosition);
        }
    }
}