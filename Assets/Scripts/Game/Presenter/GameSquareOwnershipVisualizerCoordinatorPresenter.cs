using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.GameMaster;
using Scripts.Game.Model.Player;
using Scripts.Game.View.PlayerOwnershipVisualizer;

namespace Scripts.Game.Presenter
{
    public sealed class GameSquareOwnershipVisualizerCoordinatorPresenter
    {
        public GameSquareOwnershipVisualizerCoordinatorPresenter(   GameSquareOwnershipVisualizerCoordinator view,
                                                                    RealEstateBuyingMaster realEstateBuyingMaster,
                                                                    PlayerRepository playerRepository,
                                                                    GameBoardInfo gameBoard  )
        {
            _view = view;
            _realEstateBuyingMaster = realEstateBuyingMaster;
            _playerRepository = playerRepository;
            _gameBoard = gameBoard;
            _realEstateBuyingMaster.PlayerBuyedSquare += PlayerBuyedSquareHandler;
        }


        private GameSquareOwnershipVisualizerCoordinator _view;
        private RealEstateBuyingMaster _realEstateBuyingMaster;
        private PlayerRepository _playerRepository;
        private GameBoardInfo _gameBoard;


        private void PlayerBuyedSquareHandler(PlayerInfo player, OwnableSquare ownableSquare)
        {
            int playerId = _playerRepository.GetPlayerID(player);
            if(playerId <= -1)
                return;
            int gameSquareID = _gameBoard.GetGameSquareID(ownableSquare);
            if(gameSquareID <= -1)
                return;
            _view.VisualizeOwnership((uint) gameSquareID, (uint) playerId);
        }
    }
}