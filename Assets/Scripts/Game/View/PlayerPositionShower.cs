using Scripts.Game.Presenter;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View
{
    public sealed class PlayerPositionShower : MonoBehaviour
    {
        [SerializeField] private GameSquarePlayersPlacer[] _gameSquarePlayersPlacers;
        [SerializeField] private PlayersPawn[] _playersPawns;

        private PlayerPositionShowerPresenter _presenter;


        [Inject] 
        public void Constructor(PlayerPositionShowerPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
        }


        public void MovePlayersPawn(int playersPawnID, uint gameSquareID) 
            => _gameSquarePlayersPlacers[gameSquareID].PlacePlayerOnGameSquare(_playersPawns[playersPawnID]);
    }
}