using Scripts.Game.Presenter.ConstructionMode;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Scripts.Game.View.ConstructionMode
{
    public class GameSquareConstructionBulder : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameSquare _gameSquare;

        private GameSquareConstructionBulderPresenter _presenter;


        [Inject]
        private void Constructor(GameSquareConstructionBulderPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
        }


        #region IPointerClickHandler
        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Пользователь нажал на постройку здания");
                _presenter.BuildBuildingOnGameSquare(_gameSquare.GameSquareID);
            }
            
        }
        #endregion
    }
}
