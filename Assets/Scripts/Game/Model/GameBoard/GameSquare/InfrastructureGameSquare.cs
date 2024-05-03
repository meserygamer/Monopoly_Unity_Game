using Scripts.Game.Model.Player;

#nullable enable

namespace Scripts.Game.Model.GameField.GameSquare
{
    public class InfrastructureGameSquare : OwnableSquare
    {
        public InfrastructureGameSquare(string label, uint cost) : base(null, cost)
        {
            _label = label;
        }


        private string _label;


        public override string Label => _label; 


        public override void ChangeOwner(PlayerInfo newOwner)
        {
            if(newOwner == null)
                return;
            Owner = newOwner;
        }
    }
}