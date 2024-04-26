namespace Scripts.Game.Player
{
    /// <summary>
    /// Фабрика для создания данных об игроках
    /// </summary>
    public sealed class PlayerInfoFactory
    {
        public PlayerInfo CreatePlayerInfo(string name, int moneyByDefault)
        {
            PlayerInfo playerInfo = new PlayerInfo() { Name = name };
            playerInfo.BankAccount.MoneyAmount = moneyByDefault;
            return new PlayerInfo();
        }
    }
}