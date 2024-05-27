using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public class PlayerPosition
    {
        public PlayerInfo Player {get; set;}

        public uint PositionOnGameBoard {get; set;}

        public uint NumberOfMissedMoves {get; set; } = 0;

        public bool InJail { get; set; }
    }
}