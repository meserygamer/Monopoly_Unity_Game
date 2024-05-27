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
        [SerializeField] private GameSquarePlayersPlacer _jailGameSquarePlacer;

        private Dictionary<int, (uint, bool)> _currentPlayersPawnPositions = new Dictionary<int, (uint, bool)>();

        private PlayerPositionShowerPresenter _presenter;


        [Inject] 
        public void Constructor(PlayerPositionShowerPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
        }


        public void MovePlayersPawn(int playersPawnID, uint gameSquareID)
        {
            FreePreviousPlayerPlace(playersPawnID);
            UpdatePlayerPositionData(playersPawnID, gameSquareID, false);
            _gameSquarePlayersPlacers[gameSquareID].PlacePlayerOnGameSquare(_playersPawns[playersPawnID]);
        }

        public void MovePlayerIntoJail(int playersPawnID, uint jailPosition)
        {
            FreePreviousPlayerPlace(playersPawnID);
            UpdatePlayerPositionData(playersPawnID, jailPosition, true);
            _jailGameSquarePlacer.PlacePlayerOnGameSquare(_playersPawns[playersPawnID]);
        }

        private void FreePreviousPlayerPlace(int playersPawnID)
        {
            if (!_currentPlayersPawnPositions.ContainsKey(playersPawnID))
                return;

            GameSquarePlayersPlacer previousPlayersPlacer;
            (uint, bool) playersPosition = _currentPlayersPawnPositions[playersPawnID];
            if (playersPosition.Item2)
                previousPlayersPlacer = _jailGameSquarePlacer;
            else
                previousPlayersPlacer = _gameSquarePlayersPlacers[playersPosition.Item1];
            previousPlayersPlacer.FreePlaceOnGameSquare(_playersPawns[playersPawnID]);
        }

        private void UpdatePlayerPositionData(int playersPawnID, uint gameSquareID, bool isPlayerInJail)
        {
            (uint, bool) newPlayerPosition = (gameSquareID, isPlayerInJail);
            if (_currentPlayersPawnPositions.ContainsKey(playersPawnID))
                _currentPlayersPawnPositions[playersPawnID] = newPlayerPosition;
            else
                _currentPlayersPawnPositions.Add(playersPawnID, newPlayerPosition);
        }
    }
}