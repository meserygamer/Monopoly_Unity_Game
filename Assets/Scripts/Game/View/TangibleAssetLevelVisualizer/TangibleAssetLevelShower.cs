using System;
using System.Collections.Generic;
using Scripts.Game.Presenter.TangibleAssetLevelVisualizer;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View.TangibleAssetLevelVisualizer
{
    [RequireComponent(typeof(GameSquare))]
    public sealed class TangibleAssetLevelShower : MonoBehaviour
    {
        [SerializeField] private GameObject _firstHouse;
        [SerializeField] private GameObject _secondHouse;
        [SerializeField] private GameObject _thirdHouse;
        [SerializeField] private GameObject _fourthHouse;
        [SerializeField] private GameObject _hotel;

        private GameSquare _gameSquare;

        private TangibleAssetLevelShowerPresenter _presenter;

        private Dictionary<uint, Action> _levelShowers;


        public uint TrackedTangibleAssetID => _gameSquare.GameSquareID;


        [Inject]
        private void Constructor(TangibleAssetLevelShowerPresenter presenter)
        {
            _presenter = presenter;
            _levelShowers = new Dictionary<uint, Action>()
            {
                { 0, ShowZeroLevel},
                { 1, ShowFirstLevel},
                { 2, ShowSecondLevel},
                { 3, ShowThirdLevel},
                { 4, ShowFourthLevel},
                { 5, ShowFifthLevel},
            };
        }


        #region MonoBehavior
        private void Awake()
        {
            _gameSquare = GetComponent<GameSquare>();
        }

        private void Start()
        {
            _presenter.View = this;
            _presenter.UpdateTangibleAssetLevel();
        }
        #endregion


        public void UpdateShowingTangibleAssetLevel(uint newAssetLevel) => _levelShowers[newAssetLevel]?.Invoke();

        private void ShowZeroLevel()
        {
            _firstHouse.SetActive(false);
            _secondHouse.SetActive(false);
            _thirdHouse.SetActive(false);
            _fourthHouse.SetActive(false);
            _hotel.SetActive(false);
        }
        private void ShowFirstLevel()
        {
            _firstHouse.SetActive(true);
            _secondHouse.SetActive(false);
            _thirdHouse.SetActive(false);
            _fourthHouse.SetActive(false);
            _hotel.SetActive(false);
        }
        private void ShowSecondLevel()
        {
            _firstHouse.SetActive(true);
            _secondHouse.SetActive(true);
            _thirdHouse.SetActive(false);
            _fourthHouse.SetActive(false);
            _hotel.SetActive(false);
        }
        private void ShowThirdLevel()
        {
            _firstHouse.SetActive(true);
            _secondHouse.SetActive(true);
            _thirdHouse.SetActive(true);
            _fourthHouse.SetActive(false);
            _hotel.SetActive(false);
        }
        private void ShowFourthLevel()
        {
            _firstHouse.SetActive(true);
            _secondHouse.SetActive(true);
            _thirdHouse.SetActive(true);
            _fourthHouse.SetActive(true);
            _hotel.SetActive(false);
        }
        private void ShowFifthLevel()
        {
            _firstHouse.SetActive(false);
            _secondHouse.SetActive(false);
            _thirdHouse.SetActive(false);
            _fourthHouse.SetActive(false);
            _hotel.SetActive(true);
        }
    }
}