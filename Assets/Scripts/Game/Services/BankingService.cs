using System;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public class BankingService
    {
        public BankingService(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        private PlayerRepository _playerRepository;


        public void GivePlayerMoney(int playerID, uint MoneyAmount) => 
            _playerRepository.PlayersInfo[playerID].BankAccount.MoneyAmount += Convert.ToInt32(MoneyAmount);
        public void TakePlayerMoney(int playerID, uint MoneyAmount) =>
            _playerRepository.PlayersInfo[playerID].BankAccount.MoneyAmount -= Convert.ToInt32(MoneyAmount);

        public bool TakePlayerMoneyIfEnoughtMoney(int playerID, uint MoneyAmount)
        {
            PlayerInfo playerInfo = _playerRepository.PlayersInfo[playerID];
            if(playerInfo.BankAccount.MoneyAmount < MoneyAmount) 
                return false;
            TakePlayerMoney(playerID, MoneyAmount);
            return true;
        }

    }
}