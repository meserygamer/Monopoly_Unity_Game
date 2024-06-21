using Scripts.Game.View;
using UnityEngine;
using UnityEngine.UI;


namespace Scripts.DemoModeGame.View
{
    public class DiceAnimationSwitcher : MonoBehaviour
    {
        [SerializeField] private Toggle _switcher;
        [SerializeField] private PlayersMovesTurn _playersMovesTurn;


        public void SwitcherValueChangedHandler() => 
            _playersMovesTurn.isMovePlayersPawnWithAnimation = _switcher.isOn;
    }
}