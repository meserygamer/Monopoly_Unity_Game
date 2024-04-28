using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game.View
{
    public sealed class GameSquarePlayersPlacer : MonoBehaviour
    {
        [SerializeField] Transform[] _playerPlacements;
        private Stack<Transform> _freePlacementPoints;
        private Dictionary<PlayersPawn, Transform> _busyPlacementsPoints;


        private void Awake()
        {
            _freePlacementPoints = new Stack<Transform>(_playerPlacements);
            _busyPlacementsPoints = new Dictionary<PlayersPawn, Transform>();
        }


        public bool PlacePlayerOnGameSquare(PlayersPawn player)
        {
            if(_freePlacementPoints.Count == 0)
                return false;
            if(player is null)
                return false;
            Transform occupiedPlace = _freePlacementPoints.Pop();
            _busyPlacementsPoints.Add(player, occupiedPlace);
            MovePlayerToOccupiedPlace(player, occupiedPlace);
            return true;
        }
        public bool FreePlaceOnGameSquare(PlayersPawn player)
        {
            Transform freePlace;
            if(player is null)
                return false;
            if(!_busyPlacementsPoints.TryGetValue(player, out freePlace))
                return false;
            _busyPlacementsPoints.Remove(player);
            _freePlacementPoints.Push(freePlace);

            return true;
        }

        private void MovePlayerToOccupiedPlace(PlayersPawn player, Transform occupiedPlace)
        {
            player.gameObject.transform.SetParent(occupiedPlace, true);
            player.gameObject.transform.SetLocalPositionAndRotation(new Vector3(), new Quaternion());
        }
    }
}