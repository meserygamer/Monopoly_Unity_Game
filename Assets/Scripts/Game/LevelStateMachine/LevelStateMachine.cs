using System;
using System.Collections.Generic;

namespace Scripts.Game.StateMachine
{
    public class LevelStateMachine
    {
        public LevelStateMachine(LevelStates levelStates)
        {
            levelStates.BuyingGameSquareState.StateMachine = this;
            levelStates.StartLevelState.StateMachine = this;
            levelStates.GoingGameState.StateMachine = this;
            
            _levelStates = new Dictionary<Type, LevelState>()
            {
                {typeof(StartLevelState), levelStates.StartLevelState},
                {typeof(GoingGameState), levelStates.GoingGameState},
                {typeof(BuyingGameSquareState), levelStates.BuyingGameSquareState}
            };
        }


        private Dictionary<Type, LevelState> _levelStates;
        private LevelState _currentLevelState;


        public void EnterIn<TState>() where TState : LevelState
        {
            if(_levelStates.TryGetValue(typeof(TState), out LevelState state))
            {
                _currentLevelState?.ExitFromState();
                _currentLevelState = state;
                _currentLevelState.EnterInState();
            }
        }
    }
}