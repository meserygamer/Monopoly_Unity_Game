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
            _gameBoardInfo = gameBoard;
            GameBoardJail = new GameBoardJail();

            playerRepository.PlayersInfoRegenerated += PlayersInfoRegeneratedHandler;
        }


        ~PlayerMovementService()
        {
            _playerRepository.PlayersInfoRegenerated -= PlayersInfoRegeneratedHandler;
        }


        private const uint JAIL_SQUARE_INDEX = 10;
        private const uint GO_TO_JAIL_SQUARE_INDEX = 30;


        private GameBoardInfo _gameBoardInfo;
        private PlayerRepository _playerRepository;


        public event Action<PlayerInfo, int, uint?, uint> PlayerPositionChanged;


        public List<PlayerPosition> PlayersPositions { get; } = new List<PlayerPosition>();

        public GameBoardJail GameBoardJail { get; }


        private void PlayersInfoRegeneratedHandler() => GeneratePositionsForNewPlayers(_playerRepository.PlayersInfo.ToArray());


        public void MovePlayer(PlayerInfo player, uint passedGameSquaresCount)
        {
            PlayerPosition playerPosition = PlayersPositions.Find(a => a.Player == player);
            uint newPlayerPosition = GetNewPlayerPosition(playerPosition, passedGameSquaresCount);
            uint? passedGameSquaresCountNullable = passedGameSquaresCount;
            if(newPlayerPosition == GO_TO_JAIL_SQUARE_INDEX)
            {
                GameBoardJail.PutPlayerInJail(player);
                newPlayerPosition = JAIL_SQUARE_INDEX;
                passedGameSquaresCountNullable = null;
            }

            playerPosition.PositionOnGameBoard = newPlayerPosition;
            PlayerPositionChanged?.Invoke(player, PlayersPositions.IndexOf(playerPosition), passedGameSquaresCountNullable, playerPosition.PositionOnGameBoard);
        }

        public void MovePlayerToDestinationPoint(PlayerInfo player, uint destinationPointID)
        {
            PlayerPosition playerPosition = PlayersPositions.Find(a => a.Player == player);
            int passedGameSquaresCount = (int)destinationPointID - (int)playerPosition.PositionOnGameBoard;
            playerPosition.PositionOnGameBoard = destinationPointID % (uint)_gameBoardInfo.GameSquares.Count;
            PlayerPositionChanged?.Invoke(player, PlayersPositions.IndexOf(playerPosition), (uint)passedGameSquaresCount, playerPosition.PositionOnGameBoard);
        }

        public uint? GetPlayerPosition(PlayerInfo playerInfo) => PlayersPositions.Where(a => a.Player == playerInfo).FirstOrDefault()?.PositionOnGameBoard;

        public PlayerPosition GetPlayerPositionInfo(PlayerInfo playerInfo) => PlayersPositions.Where(a => a.Player == playerInfo).FirstOrDefault();

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