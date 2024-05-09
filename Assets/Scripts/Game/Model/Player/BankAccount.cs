using System;
using System.Collections.Generic;
using Scripts.Game.Model.GameField.GameSquare;

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

        public HashSet<OwnableSquare> GameSquaresInPossession { get; } = new HashSet<OwnableSquare>();
    }
}