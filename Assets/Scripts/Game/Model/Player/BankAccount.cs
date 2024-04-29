using System;

namespace Scripts.Game.Model.Player
{
    public sealed class BankAccount
    {
        private int _moneyAmount = 0;

        
        public event Action<BankAccount> BankAccountMoneyAmountChanged;


        public int MoneyAmount
        {
            get => _moneyAmount;
            set
            {
                _moneyAmount = value;
                BankAccountMoneyAmountChanged?.Invoke(this);
            }
        }
    }
}