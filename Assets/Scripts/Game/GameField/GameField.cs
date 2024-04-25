using Scripts.Game.GameSquares;
using Scripts.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Game
{
    public class GameField : MonoBehaviour
    {
        [SerializeField] private GameSquare[] _simpleGameCycleGameSquares;
        [SerializeField] private GameSquare _jailGameSquares;
        private List<PlayerLocation> _playersLocationOnBoard = new List<PlayerLocation>();


        public void SetPlayersOnBoard(Player[] players)
        {
            _playersLocationOnBoard.Clear();
            foreach (var player in players)
            {
                PlayerLocation playerLocation = new PlayerLocation() { Player = player, Position = 0 };
                _playersLocationOnBoard.Add(playerLocation);
                VisualMovePlayerOnBoard(playerLocation, 0);
            }
        }
        public void MovePlayerOnBoard(Player player, uint passedGameSquaresCount)
        {
            PlayerLocation playerLocation = _playersLocationOnBoard.Where(a => a.Player == player).FirstOrDefault();
            if (playerLocation.Equals(new PlayerLocation() { Player = null, Position = 0 }))
                return;
            uint newPlayerPostion = GetNewPlayerPosition(playerLocation, passedGameSquaresCount);
            VisualMovePlayerOnBoard(playerLocation, newPlayerPostion);
            playerLocation.Position = newPlayerPostion;
        }

        private uint GetNewPlayerPosition(PlayerLocation location, uint passedGameSquaresCount)
        {
            uint newPlayerPostion = location.Position; 
            newPlayerPostion += passedGameSquaresCount % Convert.ToUInt32(_simpleGameCycleGameSquares.Length);
            if(newPlayerPostion >= _simpleGameCycleGameSquares.Length)
                newPlayerPostion -= Convert.ToUInt32(_simpleGameCycleGameSquares.Length);
            return newPlayerPostion;
        }
        private void VisualMovePlayerOnBoard(PlayerLocation playerLocation, uint destinationPoint)
        {
            PlayerPlacerOnGameSquare oldPlayerPlacer = _simpleGameCycleGameSquares[playerLocation.Position].GetComponent<PlayerPlacerOnGameSquare>();
            PlayerPlacerOnGameSquare newPlayerPlacer = _simpleGameCycleGameSquares[destinationPoint].GetComponent<PlayerPlacerOnGameSquare>();
            if(oldPlayerPlacer is not null)
                oldPlayerPlacer.FreePlaceOnGameSquare(playerLocation.Player);
            if(newPlayerPlacer is null)
                return;
            newPlayerPlacer.PlacePlayerOnGameSquare(playerLocation.Player);
        }
    }
}
