using System;
using System.Collections.Generic;

namespace Scripts.Game.FinalStateMachine
{
    public class LevelStateMachine
    {
        public LevelStateMachine(LevelStates levelStates)
        {
            levelStates.BuyingGameSquareState.LevelStateMachine = this;
            
            _levelStates = new Dictionary<Type, ILevelState>()
            {
                {typeof(StartLevelState), levelStates.StartLevelState},
                {typeof(GoingGameState), levelStates.GoingGameState},
                {typeof(BuyingGameSquareState), levelStates.BuyingGameSquareState}
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
