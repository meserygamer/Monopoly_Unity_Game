using System.Collections.Generic;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public sealed class PlayersMovesTurnService
    {
        public PlayersMovesTurnService(PlayerRepository playerRepository, DiceRollService diceRollService, PlayerMovementService playerMovementService)
        {
            _playerRepository = playerRepository;
            _diceRollService = diceRollService;
            _playerMovementService = playerMovementService;
            _movesTurn = new Queue<PlayerInfo>(_playerRepository.PlayersInfo);
            _playerRepository.PlayersInfoRegenerated += PlayersInfoRegeneratedHandler;
        }


        private PlayerRepository _playerRepository;
        private DiceRollService _diceRollService;
        private PlayerMovementService _playerMovementService;

        public Queue<PlayerInfo> _movesTurn;


        public PlayerInfo MakingTurnPlayer { get; private set; }


        public void DoNextMove()
        {
            MakingTurnPlayer = GetNextPlayer();

            DiceRoll playersDiceRoll = _diceRollService.SimulatePlayerRollDice(MakingTurnPlayer);
            _playerMovementService.MovePlayer(MakingTurnPlayer, playersDiceRoll.SumCameUpNumbers);
        }

        private void PlayersInfoRegeneratedHandler()
        {
            _movesTurn = new Queue<PlayerInfo>(_playerRepository.PlayersInfo);
        }

        private PlayerInfo GetNextPlayer()
        {
            PlayerInfo nextPlayer = null;
            do
            {
                if (_movesTurn.Count == 0)
                _movesTurn = new Queue<PlayerInfo>(_playerRepository.PlayersInfo);

                nextPlayer = _movesTurn.Dequeue();
                if(_playerMovementService.GameBoardJail.IsPlayerInJail(nextPlayer))
                {
                    _playerMovementService.GameBoardJail.ReduceMovesInJail(nextPlayer);
                    nextPlayer = null;
                }
            } while (nextPlayer is null);
            return nextPlayer;
        }

    }
}
