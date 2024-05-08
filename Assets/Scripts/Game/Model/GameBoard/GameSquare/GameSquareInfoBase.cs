namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Квадрат игрового поля
    /// </summary>
    public abstract class GameSquareInfoBase
    {
        public virtual string Label { get; } = "Игровая клетка";
    }
}