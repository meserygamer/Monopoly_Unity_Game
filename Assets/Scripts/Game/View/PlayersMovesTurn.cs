using Scripts.Game.Presenter;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View
{
    public sealed class PlayersMovesTurn : MonoBehaviour
    {
        private PlayersMovesTurnPresenter _presenter;


        [Inject]
        private void Constructor(PlayersMovesTurnPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
        }


        public void PassMoveOn()
        {
            _presenter.DoNextMove();
        }
    }
}
