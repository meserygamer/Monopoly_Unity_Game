using System.Collections.Generic;
using System;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services
{
    public class DiceRollService
    {
        private readonly Dictionary<PlayerInfo, List<DiceRoll>> _rollHistory = 
            new Dictionary<PlayerInfo, List<DiceRoll>>();


        public DiceRoll SimulatePlayerRollDice(PlayerInfo player)
        {
            if (player is null)
                throw new ArgumentNullException();
            DiceRoll diceRoll = new DiceRoll()
            {
                FirstCameUpNumber = RollDice(),
                SecondCameUpNumber = RollDice()
            };
            AddDiceRollToHistory(player, diceRoll);
            return diceRoll;
        }

        private uint RollDice()
        {
            return Convert.ToUInt32(new Random().Next(1, 7));
        }
        private void AddDiceRollToHistory(PlayerInfo player, DiceRoll diceRoll)
        {
            List<DiceRoll> _playerDiceRolls;
            if (_rollHistory.TryGetValue(player, out _playerDiceRolls))
            {
                _playerDiceRolls.Add(diceRoll);
            }
            else
            {
                _playerDiceRolls = new List<DiceRoll>();
                _rollHistory.Add(player, _playerDiceRolls);
            }
        }
    }
}