using Scripts.Game.Model.Player;
using UnityEngine;

namespace Scripts.Game.FinalStateMachine
{
    public class StartLevelState : ILevelState
    {
        public StartLevelState(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        private PlayerRepository _playerRepository;


        public void EnterInState()
        {
            Application.targetFrameRate = 90;
            _playerRepository.GeneratePlayers(4);
        }

        public void ExitFromState(){}
    }
}