using System;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public class BankingService
    {
        public BankingService(){}


        public void GivePlayerMoney(PlayerInfo player, uint MoneyAmount) => 
            player.BankAccount.MoneyAmount += Convert.ToInt32(MoneyAmount);
        public void TakePlayerMoney(PlayerInfo player, uint MoneyAmount) =>
            player.BankAccount.MoneyAmount -= Convert.ToInt32(MoneyAmount);

        public bool TakePlayerMoneyIfEnought(PlayerInfo player, uint MoneyAmount)
        {
            if(player.BankAccount.MoneyAmount < MoneyAmount) 
                return false;
            TakePlayerMoney(player, MoneyAmount);
            return true;
        }

        public void TransferMoneyBetweenPlayers(PlayerInfo from, PlayerInfo to, uint TransferMoneyAmount)
        {
            GivePlayerMoney(to, TransferMoneyAmount);
            TakePlayerMoney(from, TransferMoneyAmount);
        }
    }
}