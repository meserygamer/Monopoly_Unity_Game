namespace Scripts.Game.Dice
{
    public record DiceRoll
    {
        public uint FirstCameUpNumber { get; set; }
        public uint SecondCameUpNumber { get; set; }
        public uint SumCameUpNumbers => FirstCameUpNumber + SecondCameUpNumber;
    }
}