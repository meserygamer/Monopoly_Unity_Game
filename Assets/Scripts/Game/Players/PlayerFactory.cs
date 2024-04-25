using UnityEngine;

namespace Scripts.Game.Players
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private Player[] _playerPrefabs;
        private int _nextPrefabIndex = 0;


        public Player CreatePlayer()
        {
            if (_playerPrefabs.Length == _nextPrefabIndex) _nextPrefabIndex = 0;
            return Instantiate(_playerPrefabs[_nextPrefabIndex++]);
        }

        public Player[] CreatePlayers(int playersCount)
        {
            Player[] players = new Player[playersCount];
            for (int i = 0; i < playersCount; i++)
            {
                players[i] = CreatePlayer();
            }
            return players;
        }
    }
}
