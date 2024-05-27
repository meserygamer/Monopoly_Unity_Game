using System;
using System.Collections.Generic;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;

namespace Scripts.Game.Model.GameMaster
{
    public sealed class ParkingMaster
    {
        public ParkingMaster(PlayerMovementService playerMovementService, GameBoardInfo boardInfo)
        {
            _playerMovementService = playerMovementService;
            _boardInfo = boardInfo;

            _playerMovementService.PlayerPositionChanged += PlayerPositionChangedHandler;
        }


        private const uint MISSING_MOVES_FOR_PARKING = 1;


        private readonly PlayerMovementService _playerMovementService;
        private readonly GameBoardInfo _boardInfo;


        private void PlayerPositionChangedHandler(PlayerInfo player, int playerID, uint? passedGameSquares, uint newPlayerPosition)
        {
            /*if(_boardInfo.GameSquares[(int)newPlayerPosition] is ParkingGameSquare)
                PlacePlayerOnParking(player);*/
        }

        /*
        private void PlacePlayerOnParking(PlayerInfo player)
        {
            _playerMovementService.GetPlayerPositionInfo(player).NumberOfMissedMoves = MISSING_MOVES_FOR_PARKING;
        }
        */
    }
}