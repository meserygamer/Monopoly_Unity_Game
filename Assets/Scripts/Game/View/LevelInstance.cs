using Scripts.Game.FinalStateMachine;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View
{
    public class LevelInstance : MonoBehaviour
    {
        private LevelStateMachine _levelStateMachine;


        [Inject]
        private void Constructor(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }


        private void Start()
        {
            _levelStateMachine.EnterIn<StartLevelState>();
            _levelStateMachine.EnterIn<GoingGameState>();
        }
    }
}
