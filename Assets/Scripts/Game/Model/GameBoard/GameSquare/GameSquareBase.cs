namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Квадрат игрового поля
    /// </summary>
    public abstract class GameSquareBase
    {
        public virtual string Label { get; } = "Игровая клетка";
    }
}