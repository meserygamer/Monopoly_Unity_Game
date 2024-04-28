using System.Collections.Generic;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public sealed class PlayersMovesTurnService
    {
        public PlayersMovesTurnService(PlayerRepository playerRepository, DiceRollService diceRollService, PlayerMovementService playerMovementService)
        {
            _playerRepository = playerRepository;
            _movesTurn = new Queue<PlayerInfo>(_playerRepository.PlayersInfo);
            _playerRepository.PlayersInfoRegenerated += PlayersInfoRegeneratedHandler;
            _diceRollService = diceRollService;
            _playerMovementService = playerMovementService;
        }


        private PlayerRepository _playerRepository;
        private DiceRollService _diceRollService;
        private PlayerMovementService _playerMovementService;

        public Queue<PlayerInfo> _movesTurn;


        public void DoNextMove()
        {
            if (_movesTurn.Count == 0)
                _movesTurn = new Queue<PlayerInfo>(_playerRepository.PlayersInfo);
            PlayerInfo playerWhoThrowsDice = _movesTurn.Dequeue();
            DiceRoll playersDiceRoll = _diceRollService.SimulatePlayerRollDice(playerWhoThrowsDice);
            _playerMovementService.MovePlayer(playerWhoThrowsDice, playersDiceRoll.SumCameUpNumbers);
        }

        private void PlayersInfoRegeneratedHandler()
        {
            _movesTurn = new Queue<PlayerInfo>(_playerRepository.PlayersInfo);
        }

    }
}
