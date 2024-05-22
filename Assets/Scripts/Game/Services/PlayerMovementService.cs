using System;
using System.Collections.Generic;
using System.Linq;
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


        public event Action<PlayerInfo, int, uint?, uint> PlayerPositionChanged;


        public List<PlayerPosition> PlayersPositions { get; } = new List<PlayerPosition>();


        private void PlayersInfoRegeneratedHandler() => GeneratePositionsForNewPlayers(_playerRepository.PlayersInfo.ToArray());


        public void MovePlayer(PlayerInfo player, uint passedGameSquaresCount)
        {
            PlayerPosition playerPosition = PlayersPositions.Find(a => a.Player == player);
            playerPosition.PositionOnGameBoard = GetNewPlayerPosition(playerPosition, passedGameSquaresCount);
            PlayerPositionChanged?.Invoke(player, PlayersPositions.IndexOf(playerPosition), passedGameSquaresCount, playerPosition.PositionOnGameBoard);
        }

        public void MovePlayerToDestinationPoint(PlayerInfo player, uint destinationPointID)
        {
            PlayerPosition playerPosition = PlayersPositions.Find(a => a.Player == player);
            int passedGameSquaresCount = (int)destinationPointID - (int)playerPosition.PositionOnGameBoard;
            playerPosition.PositionOnGameBoard = destinationPointID % (uint)_gameBoardInfo.GameSquares.Count;
            PlayerPositionChanged?.Invoke(player, PlayersPositions.IndexOf(playerPosition), (uint)passedGameSquaresCount, playerPosition.PositionOnGameBoard);
        }

        public uint? GetPlayerPosition(PlayerInfo playerInfo) => PlayersPositions.Where(a => a.Player == playerInfo).FirstOrDefault()?.PositionOnGameBoard;

        private void GeneratePositionsForNewPlayers(PlayerInfo[] playerInfos)
        {
            PlayersPositions.Clear();
            for(int i = 0; i < playerInfos.Length; i++)
            {
                PlayersPositions.Add(new PlayerPosition { Player = playerInfos[i], PositionOnGameBoard = 0 });
                PlayerPositionChanged?.Invoke(playerInfos[i], i, null, 0);
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