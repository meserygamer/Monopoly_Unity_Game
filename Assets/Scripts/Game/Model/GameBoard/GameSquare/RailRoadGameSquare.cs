using Scripts.Game.Model.Player;

#nullable enable

namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Квадрат игрового поля с железной дорогой
    /// </summary>
    public class RailRoadGameSquare : OwnableSquare
    {
        public RailRoadGameSquare(string label, uint cost) : base(null, cost)
        {
            _label = label;
        }


        private string _label;


        public override string Label => _label;
    }
}