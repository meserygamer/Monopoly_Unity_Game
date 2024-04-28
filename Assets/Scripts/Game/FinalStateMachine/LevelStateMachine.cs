using System;
using System.Collections.Generic;
using Scripts.Game.Model.Player;

namespace Scripts.Game.FinalStateMachine
{
    public class LevelStateMachine
    {
        public LevelStateMachine(PlayerRepository playerRepository)
        {
            _levelStates = new Dictionary<Type, ILevelState>()
            {
                {typeof(StartLevelState), new StartLevelState(playerRepository)},
                {typeof(GoingGameState), new GoingGameState()}
            };
        }


        private Dictionary<Type, ILevelState> _levelStates;
        private ILevelState _currentLevelState;


        public void EnterIn<TState>() where TState : ILevelState
        {
            if(_levelStates.TryGetValue(typeof(TState), out ILevelState state))
            {
                _currentLevelState?.ExitFromState();
                _currentLevelState = state;
                _currentLevelState.EnterInState();
            }
        }
    }
}
