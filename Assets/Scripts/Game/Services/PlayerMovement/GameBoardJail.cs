using System.Collections.Generic;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public sealed class GameBoardJail
    {
        public GameBoardJail()
        {
            _playersInJail = new Dictionary<PlayerInfo, uint>();
        }


        public const uint MISSING_MOVES_IN_JAIL = 3;


        private readonly Dictionary<PlayerInfo, uint> _playersInJail;


        public void PutPlayerInJail(PlayerInfo playerInfo)
        {
            if(_playersInJail.ContainsKey(playerInfo))
                return;
            
            _playersInJail.Add(playerInfo, MISSING_MOVES_IN_JAIL);
        }

        public bool IsPlayerInJail(PlayerInfo playerInfo) => _playersInJail.ContainsKey(playerInfo);

        public void ReduceMovesInJail(PlayerInfo playerInfo)
        {
            if(!_playersInJail.ContainsKey(playerInfo))
                return;

            _playersInJail[playerInfo] -= 1;
            if(_playersInJail[playerInfo] == 0)
                _playersInJail.Remove(playerInfo);
        }
    }
}