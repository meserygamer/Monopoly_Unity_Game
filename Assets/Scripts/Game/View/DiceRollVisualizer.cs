using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Game.View
{
    public class DiceRollVisualizer : MonoBehaviour
    {
        [SerializeField] private DiceAnimator _firstDice;
        [SerializeField] private DiceAnimator _secondDice;

        private int _diceRollAnimationEndedCount = 0;


        public event Action DiceRollAnimationsEnded;



        private void OnEnable()
        {
            _firstDice.DiceAnimationEnded += DiceAnimationEndedHandler;
            _secondDice.DiceAnimationEnded += DiceAnimationEndedHandler;
        }

        private void DiceAnimationEndedHandler()
        {
            _diceRollAnimationEndedCount++;
        }

        public void VisualizeDiceRoll(uint firstDiceNumber, uint secondDiceNumber)
        {
            new Task(() => _firstDice.StartDiceAnimation(firstDiceNumber)).Start();
            new Task(() => _secondDice.StartDiceAnimation(secondDiceNumber)).Start();
            while(_diceRollAnimationEndedCount != 2)
            {
                Thread.Sleep(100);
            }
            _diceRollAnimationEndedCount = 0;
            DiceRollAnimationsEnded?.Invoke();
        }
    }
}
