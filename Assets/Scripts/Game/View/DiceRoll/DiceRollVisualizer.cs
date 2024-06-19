using System;
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
        private void OnDisable()
        {
            _firstDice.DiceAnimationEnded -= DiceAnimationEndedHandler;
            _secondDice.DiceAnimationEnded -= DiceAnimationEndedHandler;
        }


        private void DiceAnimationEndedHandler()
        {
            _diceRollAnimationEndedCount++;
            if(_diceRollAnimationEndedCount >= 2)
            {
                DiceRollAnimationsEnded?.Invoke();
                _diceRollAnimationEndedCount = 0;
            }
        }


        public void VisualizeDiceRoll(uint firstDiceNumber, uint secondDiceNumber)
        {  
            _firstDice.StartDiceAnimation(firstDiceNumber);
            _secondDice.StartDiceAnimation(secondDiceNumber);
        }
    }
}
