using System.Collections.Generic;
using Scripts.Game.Model.GameField.GameSquare;

namespace Scripts.Game.Model.GameField
{
    /// <summary>
    /// Игрвое поле
    /// </summary>
    public sealed class GameBoardInfo
    {
        public List<GameSquareInfoBase> GameSquares { get; } = new List<GameSquareInfoBase>();


        public int GetGameSquareID(GameSquareInfoBase gameSquareInfoBase) => GameSquares.IndexOf(gameSquareInfoBase);
    }
}