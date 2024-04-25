using Scripts.Game.Players;
using Scripts.Game.Services;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Scripts.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameField _gameField;
        [SerializeField] private int _playersCount = 4;
        private Player[] _gamePlayers;
        private int _currentPlayerID;
        private PlayerFactory _playerFactory;
        private DiceRollService _diceRollService;


        [Inject]
        private void Construct(PlayerFactory playerFactory, DiceRollService diceRollService)
        {
            _playerFactory = playerFactory;
            _diceRollService = diceRollService;
        }


        private void Start()
        {
            _gamePlayers = _playerFactory.CreatePlayers(_playersCount);
            _gameField.SetPlayersOnBoard(_gamePlayers);
            _currentPlayerID = 0;
        }


        public void RollDiceByCurrentPlayer()
        {
            Player player = _gamePlayers[_currentPlayerID];
            DiceRoll curentPlayerDiceRoll = _diceRollService.SimulatePlayerRollDice(player);
            Debug.Log($"На кубиках выпало число - {curentPlayerDiceRoll.SumCameUpNumbers}");
            _gameField.MovePlayerOnBoard(player, curentPlayerDiceRoll.SumCameUpNumbers);
            _currentPlayerID++;
            if(_currentPlayerID >= _gamePlayers.Length)
                _currentPlayerID = 0;
        }
    }
}
