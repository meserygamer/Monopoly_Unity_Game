using Monopoly_Unity_Game_Server.Model;
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


        public virtual void ChangeOwner(PlayerInfo newOwner)
        {
            if(newOwner == null)
                return;
            newOwner.BankAccount.GameSquaresInPossession.Add(this);
            Owner = newOwner;
        }

        public abstract GameSquareExample GetGameSquareExample();
    }
}