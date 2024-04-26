using System.Collections.Generic;
using Scripts.Game.GameField.GameSquare;

namespace Scripts.Game.GameField
{
    /// <summary>
    /// Игрвое поле
    /// </summary>
    public sealed class GameFieldInfo
    {
        public List<GameSquareBase> GameSquares { get; } = new List<GameSquareBase>();
    }
}