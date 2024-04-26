using System;
using System.Collections.Generic;

namespace Scripts.Game.Player
{
    /// <summary>
    /// Хранилище данных о пользователях, участвующих в игре
    /// </summary>
    public sealed class PlayerRepository
    {
        public PlayerRepository(PlayerInfoFactory playerInfoFactory)
        {
            _playerInfoFactory = playerInfoFactory;
        }


        private List<PlayerInfo> PlayersInfo { get; } = new List<PlayerInfo>();

        private PlayerInfoFactory _playerInfoFactory;


        public event Action PlayersInfoCollectionUpdated;


        public void GeneratePlayers(uint playersCount)
        {
            PlayersInfo.Clear();
            for(uint i = 0; i < playersCount; i++)
            {
                PlayersInfo.Add(_playerInfoFactory.CreatePlayerInfo("Player №" + (i + 1), 2000));
            }
            PlayersInfoCollectionUpdated?.Invoke();
        }
    }
}