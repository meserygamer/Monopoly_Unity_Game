using Scripts.Game.Presenter;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View
{
    public sealed class PlayerPositionShower : MonoBehaviour
    {
        [SerializeField] private GameSquarePlayersPlacer[] _gameSquarePlayersPlacers;
        [SerializeField] private PlayersPawn[] _playersPawns;

        private Dictionary<int, uint> _currentPlayersPawnPositions = new Dictionary<int, uint>();

        private PlayerPositionShowerPresenter _presenter;


        [Inject] 
        public void Constructor(PlayerPositionShowerPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
        }


        public void MovePlayersPawn(int playersPawnID, uint gameSquareID)
        {
            if(_currentPlayersPawnPositions.ContainsKey(playersPawnID))
            {
                _gameSquarePlayersPlacers[_currentPlayersPawnPositions[playersPawnID]].FreePlaceOnGameSquare(_playersPawns[playersPawnID]);
                _currentPlayersPawnPositions[playersPawnID] = gameSquareID;
            }
            else
            {
                _currentPlayersPawnPositions.Add(playersPawnID, gameSquareID);
            }
            _gameSquarePlayersPlacers[gameSquareID].PlacePlayerOnGameSquare(_playersPawns[playersPawnID]);
        }
    }
}