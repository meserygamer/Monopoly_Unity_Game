using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game.View
{
    public sealed class GameSquarePlayersPlacer : MonoBehaviour
    {
        [SerializeField] Transform[] _playerPlacements;
        private Stack<Transform> _freePlacementPoints;
        private Dictionary<PlayersPawn, Transform> _busyPlacementsPoints = new Dictionary<PlayersPawn, Transform>();


        private void Awake()
        {
            _freePlacementPoints = new Stack<Transform>(_playerPlacements);
        }


        public bool PlacePlayerOnGameSquare(PlayersPawn player)
        {
            if(_freePlacementPoints.Count == 0)
                throw new System.Exception("Количество свободных мест на точке - 0");
            if(player is null)
                throw new System.Exception("PlayersPawn - null");
            Transform occupiedPlace = _freePlacementPoints.Pop();
            _busyPlacementsPoints.Add(player, occupiedPlace);
            MovePlayerToOccupiedPlace(player, occupiedPlace);
            return true;
        }
        public bool FreePlaceOnGameSquare(PlayersPawn player)
        {
            if(player is null)
                throw new System.Exception("PlayersPawn - null");
            if (!_busyPlacementsPoints.TryGetValue(player, out Transform freePlace))
                throw new System.Exception("PlayersPawn не имеет зарезервированных мест для освобождения");
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