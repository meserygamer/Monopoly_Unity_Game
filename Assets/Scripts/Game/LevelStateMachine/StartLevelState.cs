using Scripts.Game.Model.Player;
using UnityEngine;

namespace Scripts.Game.StateMachine
{
    public class StartLevelState : LevelState
    {
        public StartLevelState(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        private PlayerRepository _playerRepository;


        public override void EnterInState()
        {
            Application.targetFrameRate = 90;
            _playerRepository.GeneratePlayers(4);
            base.StateMachine.EnterIn<PlayerMakingTurnState>();
        }

        public override void ExitFromState(){}
    }
}