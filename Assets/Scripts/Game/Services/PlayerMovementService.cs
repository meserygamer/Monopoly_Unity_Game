using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public sealed class PlayerMovementService
    {
        public PlayerMovementService(PlayerInfo[] players, GameBoardInfo gameBoard)
        {
            foreach(var player in players)
            {
                PlayersPositions.Add(new PlayerPosition {Player = player, PositionOnGameBoard = 0});
            }
            _gameBoardInfo = gameBoard;
        }


        public class PlayerPosition
        {
            public PlayerInfo Player {get; set;}

            public uint PositionOnGameBoard {get; set;}
        }


        private GameBoardInfo _gameBoardInfo;


        public event Action<int, uint> PlayerPositionChanged;


        public List<PlayerPosition> PlayersPositions { get; } = new List<PlayerPosition>();


        public void MovePlayer(PlayerInfo player, uint passedgameSquaresCount)
        {
            PlayerPosition playerPosition = PlayersPositions.Find(a => a.Player == player);
            playerPosition.PositionOnGameBoard = GetNewPlayerPosition(playerPosition, passedgameSquaresCount);
            PlayerPositionChanged?.Invoke(PlayersPositions.IndexOf(playerPosition), playerPosition.PositionOnGameBoard);
        }
        public void MovePlayer(int playerID, uint passedgameSquaresCount) => MovePlayer(PlayersPositions[playerID].Player, passedgameSquaresCount);

        private uint GetNewPlayerPosition(PlayerPosition playerPosition, uint passedGameSquaresCount)
        {
            uint newPlayerPostion = playerPosition.PositionOnGameBoard;
            uint GameSquaresCount =  Convert.ToUInt32(_gameBoardInfo.GameSquares.Count);
            newPlayerPostion += GameSquaresCount;
            if(newPlayerPostion >= GameSquaresCount)
                newPlayerPostion -= GameSquaresCount;
            return newPlayerPostion;
        }

    }
}