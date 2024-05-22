namespace Scripts.Game.StateMachine
{
    public class LevelStates
    {
        public PlayerMakingTurnState PlayerMakingTurnState { get; set; }
        public StartLevelState StartLevelState { get; set; }
        public BuyingGameSquareState BuyingGameSquareState { get; set; }
        public PlayerAnswearingQuestionState PlayerAnswearingQuestionState { get; set; }
    }
}