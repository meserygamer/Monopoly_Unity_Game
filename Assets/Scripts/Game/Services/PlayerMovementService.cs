using System;
using System.Collections.Generic;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public sealed class PlayerMovementService
    {
        public PlayerMovementService(PlayerRepository playerRepository, GameBoardInfo gameBoard)
        {
            _playerRepository = playerRepository;
            playerRepository.PlayersInfoRegenerated += PlayersInfoRegeneratedHandler;
            _gameBoardInfo = gameBoard;
        }


        ~PlayerMovementService()
        {
            _playerRepository.PlayersInfoRegenerated -= PlayersInfoRegeneratedHandler;
        }


        public class PlayerPosition
        {
            public PlayerInfo Player {get; set;}

            public uint PositionOnGameBoard {get; set;}
        }


        private GameBoardInfo _gameBoardInfo;

        private PlayerRepository _playerRepository;


        public event Action<int, uint> PlayerPositionChanged;


        public List<PlayerPosition> PlayersPositions { get; } = new List<PlayerPosition>();


        public void MovePlayer(PlayerInfo player, uint passedgameSquaresCount)
        {
            PlayerPosition playerPosition = PlayersPositions.Find(a => a.Player == player);
            playerPosition.PositionOnGameBoard = GetNewPlayerPosition(playerPosition, passedgameSquaresCount);
            PlayerPositionChanged?.Invoke(PlayersPositions.IndexOf(playerPosition), playerPosition.PositionOnGameBoard);
        }
        public void MovePlayer(int playerID, uint passedgameSquaresCount) => MovePlayer(PlayersPositions[playerID].Player, passedgameSquaresCount);

        private void PlayersInfoRegeneratedHandler() => GeneratePositionsForNewPlayers(_playerRepository.PlayersInfo.ToArray());

        private void GeneratePositionsForNewPlayers(PlayerInfo[] playerInfos)
        {
            PlayersPositions.Clear();
            for(int i = 0; i < playerInfos.Length; i++)
            {
                PlayersPositions.Add(new PlayerPosition { Player = playerInfos[i], PositionOnGameBoard = 0 });
                PlayerPositionChanged?.Invoke(i, 0);
            }
        }

        private uint GetNewPlayerPosition(PlayerPosition playerPosition, uint passedGameSquaresCount)
        {
            uint newPlayerPostion = playerPosition.PositionOnGameBoard;
            uint GameSquaresCount = Convert.ToUInt32(_gameBoardInfo.GameSquares.Count);
            newPlayerPostion += passedGameSquaresCount % GameSquaresCount;
            if(newPlayerPostion >= GameSquaresCount)
                newPlayerPostion -= GameSquaresCount;
            return newPlayerPostion;
        }

    }
}