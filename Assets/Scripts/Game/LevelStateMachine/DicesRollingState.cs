using Scripts.Game.Services;
using Scripts.Game.View;

namespace Scripts.Game.StateMachine
{
    public class DicesRollingState : LevelState
    {
        public DicesRollingState(DiceRollVisualizer diceRollVisualizer, DiceRollService diceRollService)
        {
            _diceRollVisualizer = diceRollVisualizer;
            _diceRollService = diceRollService;
        }


        private DiceRollVisualizer _diceRollVisualizer;

        private DiceRollService _diceRollService;


        public override void EnterInState()
        {
        }

        public override void ExitFromState()
        {
            
        }
    }
}