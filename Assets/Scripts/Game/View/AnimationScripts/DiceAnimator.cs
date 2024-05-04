using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game.View
{
    public class DiceAnimator : MonoBehaviour
    {
        [SerializeField] private string _oneFaillingAnimationTriggerName;
        [SerializeField] private string _twoFaillingAnimationTriggerName;
        [SerializeField] private string _threeFaillingAnimationTriggerName;
        [SerializeField] private string _fourFaillingAnimationTriggerName;
        [SerializeField] private string _fiveFaillingAnimationTriggerName;
        [SerializeField] private string _sixFaillingAnimationTriggerName;

        private Animator _animator;

        private Dictionary<uint, string> _diceAimationsTriggersNames;


        public event Action DiceAnimationEnded;


        public void Awake()
        {
            _animator = GetComponent<Animator>();

            _diceAimationsTriggersNames = new Dictionary<uint, string>()
            {
                {1, _oneFaillingAnimationTriggerName},
                {2, _twoFaillingAnimationTriggerName},
                {3, _threeFaillingAnimationTriggerName},
                {4, _fourFaillingAnimationTriggerName},
                {5, _fiveFaillingAnimationTriggerName},
                {6, _sixFaillingAnimationTriggerName},
            };
        }


        public void StartDiceAnimation(uint PlayersThrowedNumber)
        {
            _diceAimationsTriggersNames.TryGetValue(PlayersThrowedNumber, out string animationTriggerName);
            if(animationTriggerName is not null)
                _animator.SetTrigger(animationTriggerName);
        }

        public void AnimationEndHandler()
        {
            DiceAnimationEnded?.Invoke();
            Debug.Log("Я закончилась");
        }
    }
}
