using Scripts.Game.Presenter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.Game.View
{
    public sealed class PlayersMovesTurn : MonoBehaviour
    {
        [SerializeField] private Button _nextMoveButton;

        private PlayersMovesTurnPresenter _presenter;


        [Inject]
        private void Constructor(PlayersMovesTurnPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
        }


        public void PassMoveOn()
        {
            _nextMoveButton.interactable = false;
            _presenter.DoNextMove();
        }
        public void UnlockButton() => _nextMoveButton.interactable = true;
    }
}
