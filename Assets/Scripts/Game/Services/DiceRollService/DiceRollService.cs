using System.Collections.Generic;
using System;
using Scripts.Game.Model.Player;
using UnityEngine;

namespace Scripts.Game.Services
{
    public class DiceRollService
    {
        public Dictionary<PlayerInfo, List<DiceRoll>> RollHistory { get; } = 
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

        public DiceRoll SimulatePlayerRollDiceWithoutHistory()
        {
            DiceRoll diceRoll = new DiceRoll()
            {
                FirstCameUpNumber = RollDice(),
                SecondCameUpNumber = RollDice()
            };
            return diceRoll;
        }

        private uint RollDice()
        {
            return Convert.ToUInt32(new System.Random().Next(1, 7));
        }

        private void AddDiceRollToHistory(PlayerInfo player, DiceRoll diceRoll)
        {
            List<DiceRoll> _playerDiceRolls;
            Debug.Log("На кубиках  - " + diceRoll.SumCameUpNumbers);
            if (RollHistory.TryGetValue(player, out _playerDiceRolls))
            {
                _playerDiceRolls.Add(diceRoll);
            }
            else
            {
                _playerDiceRolls = new List<DiceRoll>();
                RollHistory.Add(player, _playerDiceRolls);
            }
        }
    }
}