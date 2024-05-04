#nullable enable

namespace Scripts.Game.StateMachine
{
    public abstract class LevelState
    {
        public LevelStateMachine? StateMachine { get; set; }


        public abstract void EnterInState();
        public abstract void ExitFromState();
    }
}
