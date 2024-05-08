using System.Collections.Generic;
using Scripts.Game.Presenter;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View.PlayerOwnershipVisualizer
{
    public class GameSquareOwnershipVisualizerCoordinator : MonoBehaviour
    {
        [SerializeField] private GameSquareOwnershipVisualizer[] _playerOwnershipVisualizers;

        private Dictionary<uint, GameSquareOwnershipVisualizer> _ownershipVisualizersByGameSquareID = new Dictionary<uint, GameSquareOwnershipVisualizer>();

        private GameSquareOwnershipVisualizerCoordinatorPresenter _presenter;


        [Inject]
        private void Constructor(GameSquareOwnershipVisualizerCoordinatorPresenter presenter)
        {
            _presenter = presenter;
        }


        private void Start()
        {
            foreach(var ownershipVisualizer in _playerOwnershipVisualizers)
                _ownershipVisualizersByGameSquareID.Add(ownershipVisualizer.GameSquare.GameSquareID, ownershipVisualizer);
        }


        public void VisualizeOwnership(uint gameSquareID, uint playerID) => _ownershipVisualizersByGameSquareID[gameSquareID].VisualizePlayerOwnership(playerID);
    }
}