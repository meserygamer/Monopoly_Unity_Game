using System.Collections.Generic;

namespace Scripts.Game.Model.Player
{
    /// <summary>
    /// Хранилище данных о пользователях, участвующих в игре
    /// </summary>
    public sealed class PlayerRepository
    {
        private List<PlayerInfo> PlayersInfo { get; } = new List<PlayerInfo>();


        public void GeneratePlayers(uint playersCount)
        {
            PlayersInfo.Clear();
            for(uint i = 0; i < playersCount; i++)
            {
                PlayerInfo playerInfo = new PlayerInfo() {Name = "Player №" + 1};
                playerInfo.BankAccount.MoneyAmount = 2000;
                PlayersInfo.Add(playerInfo);
            }
        }
    }
}