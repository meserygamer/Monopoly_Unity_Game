using System.Threading;
using System.Threading.Tasks;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;
using Scripts.Game.View;

#if UNITY_EDITOR
using UnityEditor.Search;
#endif

namespace Scripts.Game.Presenter
{
    public sealed class PlayersMovesTurnPresenter
    {
        public PlayersMovesTurnPresenter(PlayersMovesTurnService playerMovesTurnService,
                                         PlayerMovementService playerMovementService,
                                         DiceRollVisualizer diceRollVisualizer)
        {
            _playerMovesTurnService = playerMovesTurnService;
            _playerMovementService = playerMovementService;
            _diceRollVisualizer = diceRollVisualizer;
        }


        private PlayersMovesTurnService _playerMovesTurnService;
        private PlayerMovementService _playerMovementService;
        private DiceRollVisualizer _diceRollVisualizer;

        private (DiceRoll, PlayerInfo) _playersDiceRoll;


        public PlayersMovesTurn View { get; set; }


        public void DoNextMove()
        {
            _playersDiceRoll = _playerMovesTurnService.ThrowCubes();

            if(View.isMovePlayersPawnWithAnimation)
            {
                _diceRollVisualizer.DiceRollAnimationsEnded += MovePlayersPawn;
                _diceRollVisualizer.VisualizeDiceRoll(_playersDiceRoll.Item1.FirstCameUpNumber, _playersDiceRoll.Item1.SecondCameUpNumber);
            }
            else
            {
                MovePlayersPawnWithoutAnimation();
            }
        }

        private void MovePlayersPawnWithoutAnimation()
        {
            _playerMovementService.MovePlayer(_playersDiceRoll.Item2, _playersDiceRoll.Item1.SumCameUpNumbers);
            View.UnlockButton();
        }

        private void MovePlayersPawn()
        {
            _diceRollVisualizer.DiceRollAnimationsEnded -= MovePlayersPawn;
            new Task(() => 
            {
                Thread.Sleep(1500);
                #if UNITY_EDITOR
                    Dispatcher.Enqueue(() => 
                    {
                        _playerMovementService.MovePlayer(_playersDiceRoll.Item2, _playersDiceRoll.Item1.SumCameUpNumbers);
                        View.UnlockButton();
                    });
                #else
                    MultiThreadQueue.AddInMultithreadQueue(() => 
                    {
                        _playerMovementService.MovePlayer(_playersDiceRoll.Item2, _playersDiceRoll.Item1.SumCameUpNumbers);
                        View.UnlockButton();
                    });
                #endif
            }).Start();    
        } 
    }
}