using Scripts.Game.Model.Player;

#nullable enable

namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Имущество которым можно владеть
    /// </summary>
    public abstract class OwnableSquare : GameSquareInfoBase
    {
        public OwnableSquare(PlayerInfo? defaultOwner, uint cost)
        {
            Owner = defaultOwner;
            Cost = cost;
        }


        public PlayerInfo? Owner { get; protected set; }

        public uint Cost { get; }


        public abstract void ChangeOwner(PlayerInfo newOwner);
    }
}