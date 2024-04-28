using Scripts.Game.Services;
using Scripts.Game.View;

namespace Scripts.Game.Presenter
{
    public sealed class PlayersMovesTurnPresenter
    {
        public PlayersMovesTurnPresenter(PlayersMovesTurnService playerMovesTurnService)
        {
            _playerMovesTurnService = playerMovesTurnService;
        }


        private PlayersMovesTurnService _playerMovesTurnService;


        public PlayersMovesTurn View { get; set; }


        public void DoNextMove() => _playerMovesTurnService.DoNextMove();
    }
}