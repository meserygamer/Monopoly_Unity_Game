using System;
using System.Collections.Generic;
using Scripts.Game.Presenter.ConstructionMode;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View.ConstructionMode
{
    public sealed class PurchaseOpportunityVisualizer : MonoBehaviour
    {
        [SerializeField] private GameSquare _visualizedGameSquare;

        [SerializeField] private MeshRenderer _visualization;

        [SerializeField] private Material _availableForPurchaseMaterial;
        [SerializeField] private Material _unavailableForPurchaseMaterial;
        [SerializeField] private Material _maxLevelMaterial;

        private PurchaseOpportunityVisualizerPresenter _presenter;

        private Dictionary<ConstructionOpportunityStatus, Action> _visualizersOfGameSquaresStatuses;

        private bool _isVisualizeEnabled;


        public bool IsVisualizeEnabled 
        {
            get => _isVisualizeEnabled;
            set
            {
                if(_isVisualizeEnabled == value)
                    return;
                _isVisualizeEnabled = value;
                if(_isVisualizeEnabled)
                {
                    UpdatePurchaseOpportunityVisualize();
                    return;
                }
                VisializeConstructionOnSquareImpossible();
            }
        }


        [Inject]
        private void Constructor(PurchaseOpportunityVisualizerPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
            _presenter.VisualizedGameSquareID = (int)_visualizedGameSquare.GameSquareID;
        }


        #region MonoBehavior
        private void Awake()
        {
            _visualizersOfGameSquaresStatuses = new Dictionary<ConstructionOpportunityStatus, Action>()
            {
                {ConstructionOpportunityStatus.ConstructionOnSquareImpossible, VisializeConstructionOnSquareImpossible},
                {ConstructionOpportunityStatus.MaximumBuildingLevelReachedOnSquare, VisializeMaximumBuildingLevelReachedOnSquare},
                {ConstructionOpportunityStatus.ConstructionByOwnerOnSquareImpossible, VisializeConstructionByOwnerOnSquareImpossible},
                {ConstructionOpportunityStatus.ConstructionByOwnerOnSquarePossible, VisializeConstructionByOwnerOnSquarePossible},
            };
        }
        #endregion


        public void UpdatePurchaseOpportunityVisualize()
        {
            if(!_isVisualizeEnabled)
                return;
            ConstructionOpportunityStatus gameSquareStatus = _presenter.GetBuildabilityStatusOnGameSquare();
            _visualizersOfGameSquaresStatuses[gameSquareStatus]?.Invoke();
        }

        private void VisializeConstructionOnSquareImpossible() => _visualization.materials = new Material[0];
        private void VisializeMaximumBuildingLevelReachedOnSquare() => _visualization.materials = new Material[]{ _maxLevelMaterial };
        private void VisializeConstructionByOwnerOnSquareImpossible() => _visualization.materials = new Material[]{ _unavailableForPurchaseMaterial };
        private void VisializeConstructionByOwnerOnSquarePossible() => _visualization.materials = new Material[]{ _availableForPurchaseMaterial };
    }
}