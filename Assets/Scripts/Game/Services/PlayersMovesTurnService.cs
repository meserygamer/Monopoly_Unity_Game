using System;
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


        public Queue<PlayerInfo> _movesTurn;

        private PlayerRepository _playerRepository;
        private DiceRollService _diceRollService;
        private PlayerMovementService _playerMovementService;

        private PlayerInfo _markingTurnPlayer;


        public event Action<PlayerInfo> MakingTurnPlayerPositionWasChanged;


        public PlayerInfo MakingTurnPlayer 
        { 
            get => _markingTurnPlayer;
            private set
            {
                _markingTurnPlayer = value;
                MakingTurnPlayerPositionWasChanged?.Invoke(value);
            }
        }


        public (DiceRoll, PlayerInfo) ThrowCubes()
        {
            MakingTurnPlayer = GetNextPlayer();

            DiceRoll playersDiceRoll = _diceRollService.SimulatePlayerRollDice(MakingTurnPlayer);
            return (playersDiceRoll, MakingTurnPlayer);
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
