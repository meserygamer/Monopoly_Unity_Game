using System.Collections.Generic;
using UnityEngine;
using Scripts.Game.Players;

namespace Scripts.Game.GameSquares
{
    [RequireComponent(typeof(GameSquare))]
    public class PlayerPlacerOnGameSquare : MonoBehaviour
    {
        [SerializeField] private Transform[] _placementPoints;
        private Stack<Transform> _freePlacementPoints;
        private Dictionary<Player, Transform> _busyPlacementsPoints;


        private void Awake()
        {
            _freePlacementPoints = new Stack<Transform>(_placementPoints);
            _busyPlacementsPoints = new Dictionary<Player, Transform>();
        }


        public bool PlacePlayerOnGameSquare(Player player)
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
        public bool FreePlaceOnGameSquare(Player player)
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

        private void MovePlayerToOccupiedPlace(Player player, Transform occupiedPlace)
        {
            player.gameObject.transform.SetParent(occupiedPlace, true);
            player.gameObject.transform.SetLocalPositionAndRotation(new Vector3(), new Quaternion());
        }
    }
}