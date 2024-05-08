using UnityEngine;

namespace Scripts.Game.View
{
    public class GameSquare : MonoBehaviour
    {
        [SerializeField] private uint _gameSquareID;


        public uint GameSquareID { get => _gameSquareID; set => _gameSquareID = value; }
    }
}