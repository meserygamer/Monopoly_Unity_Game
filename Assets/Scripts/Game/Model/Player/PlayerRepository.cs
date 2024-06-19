using System;
using System.Collections.Generic;

namespace Scripts.Game.Model.Player
{
    /// <summary>
    /// Хранилище данных о пользователях, участвующих в игре
    /// </summary>
    public sealed class PlayerRepository
    {
        public List<PlayerInfo> PlayersInfo { get; } = new List<PlayerInfo>();


        public Action PlayersInfoRegenerated;

        public Action<int, string> PlayersNameChanged;
        public Action<int, int> PlayersMoneyBalanceChanged;


        public void GeneratePlayers(uint playersCount)
        {
            PlayersInfo.Clear();
            for(uint i = 0; i < playersCount; i++)
            {
                PlayerInfo playerInfo = new PlayerInfo() {Name = "Игрок " + (i + 1)};
                playerInfo.BankAccount.MoneyAmount = 1500;
                PlayersInfo.Add(playerInfo);
                playerInfo.NameChanged += PlayerNameChangedHandler;
                playerInfo.BankAccount.BankAccountMoneyAmountChanged += PlayerBankAccountMoneyAmountChangedHandler;
            }
            PlayersInfoRegenerated?.Invoke();
        }

        public int GetPlayerID(PlayerInfo player) => PlayersInfo.IndexOf(player);

        private void PlayerNameChangedHandler(PlayerInfo player)
        {
            int playerIndex = PlayersInfo.FindIndex(p => p == player);
            PlayersNameChanged?.Invoke(playerIndex, player.Name);

        }
        private void PlayerBankAccountMoneyAmountChangedHandler(BankAccount playersBankAccount)
        {
            int playerIndex = PlayersInfo.FindIndex(p => p.BankAccount == playersBankAccount);
            PlayersMoneyBalanceChanged?.Invoke(playerIndex, playersBankAccount.MoneyAmount);
        }
    }
}