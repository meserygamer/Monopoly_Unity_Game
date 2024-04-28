using System;
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


        private readonly PlayerMovementService _playerMovementService;


        public PlayerPositionShower? View { get; set; } = null;


        private void UpdatePlayersPositions()
        {
            for(int i = 0; i < _playerMovementService.PlayersPositions.Count; i++)
            {
                View?.MovePlayersPawn(i, _playerMovementService.PlayersPositions[i].PositionOnGameBoard);
            }
        }

        private void PlayerPositionChangedHandler(int playerID, uint newPosition) => View?.MovePlayersPawn(playerID, newPosition);
    }
}