namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Квадрат игрового поля с налогом
    /// </summary>
    public class TaxGameSquare : GameSquareInfoBase
    {
        public TaxGameSquare(uint amountOfTax)
        {
            AmountOfTax = amountOfTax;
        }


        public uint AmountOfTax { get; }
    }
}