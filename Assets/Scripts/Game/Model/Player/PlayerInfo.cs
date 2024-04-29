using System;

namespace Scripts.Game.Model.Player
{
    /// <summary>
    /// Информация об игроке
    /// </summary>
    public sealed class PlayerInfo
    {
        private string _name = "Player";


        public event Action<PlayerInfo> NameChanged;


        public string Name 
        { 
            get => _name; 
            set
            {
                _name = value;
                NameChanged?.Invoke(this);
            }
        }

        public BankAccount BankAccount { get; } = new BankAccount();
    }
}