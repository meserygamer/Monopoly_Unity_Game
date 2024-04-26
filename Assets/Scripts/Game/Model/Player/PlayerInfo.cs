using System.ComponentModel;

namespace Scripts.Game.Player
{
    /// <summary>
    /// Информация об игроке
    /// </summary>
    public sealed class PlayerInfo : INotifyPropertyChanged
    {
        private string _name = "Player";


        public event PropertyChangedEventHandler PropertyChanged;


        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public BankAccount BankAccount { get; } = new BankAccount();


        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
