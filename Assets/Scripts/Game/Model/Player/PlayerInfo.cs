namespace Scripts.Game.Model.Player
{
    /// <summary>
    /// Информация об игроке
    /// </summary>
    public sealed class PlayerInfo
    {
        private string _name = "Player";


        public string Name { get; set; }

        public BankAccount BankAccount { get; } = new BankAccount();
    }
}