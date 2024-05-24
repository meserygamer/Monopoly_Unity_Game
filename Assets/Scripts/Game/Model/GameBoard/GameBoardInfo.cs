using System.Collections.Generic;
using Scripts.Game.Model.GameField.GameSquare;

namespace Scripts.Game.Model.GameField
{
    /// <summary>
    /// Игрвое поле
    /// </summary>
    public sealed class GameBoardInfo
    {
        public GameBoardInfo(int boardCapacity)
        {
            GameSquares = new List<GameSquareInfoBase>(boardCapacity);

            InitializeGameSquares(boardCapacity);
        }


        public List<GameSquareInfoBase> GameSquares { get; }


        public int GetGameSquareID(GameSquareInfoBase gameSquareInfoBase) => GameSquares.IndexOf(gameSquareInfoBase);

        private void InitializeGameSquares(int boardCapacity)
        {
            for(int i = 0; i < boardCapacity; i++)
                GameSquares.Add(null);
        }
    }
}