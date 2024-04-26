using System.ComponentModel;

namespace Scripts.Game.Player
{
    /// <summary>
    /// Банковкий счет игрока
    /// </summary>
    public sealed class BankAccount : INotifyPropertyChanged
    {
        private int _moneyAmount = 0;


        public event PropertyChangedEventHandler PropertyChanged;


        public int MoneyAmount
        {
            get => _moneyAmount;
            set
            {
                _moneyAmount = value;
                OnPropertyChanged(nameof(MoneyAmount));
            }
        }


        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}