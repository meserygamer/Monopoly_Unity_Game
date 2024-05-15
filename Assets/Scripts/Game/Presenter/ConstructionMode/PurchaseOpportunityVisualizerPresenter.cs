using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Services;
using Scripts.Game.View.ConstructionMode;

namespace Scripts.Game.Presenter.ConstructionMode
{
    public sealed class PurchaseOpportunityVisualizerPresenter
    {
        public PurchaseOpportunityVisualizerPresenter(  GameBoardInfo gameBoard,
                                                        ConstructionService constructionService,
                                                        PlayersMovesTurnService playersMovesTurnService )
        {
            _gameBoard = gameBoard;
            _constructionService = constructionService;
            _playersMovesTurnService = playersMovesTurnService;

        }


        private readonly GameBoardInfo _gameBoard;
        private readonly ConstructionService _constructionService;
        private readonly PlayersMovesTurnService _playersMovesTurnService;

        private int _visualizedGameSquareID = -1;


        public PurchaseOpportunityVisualizer View { get; set; }

        public int VisualizedGameSquareID 
        {
            get => _visualizedGameSquareID;
            set
            {
                if(_visualizedGameSquareID != -1)
                    (_gameBoard.GameSquares[_visualizedGameSquareID] as TangibleAssetSquare).AssetLevelChanged
                        -= VisuliazingTangibleAssetLevelChangedHandler;
                _visualizedGameSquareID = value;
                (_gameBoard.GameSquares[_visualizedGameSquareID] as TangibleAssetSquare).AssetLevelChanged 
                    += VisuliazingTangibleAssetLevelChangedHandler;
            }
        }


        public ConstructionOpportunityStatus GetBuildabilityStatusOnGameSquare()
        {
            if(IsConstructionOnGameSquareProhibited())
                return ConstructionOpportunityStatus.ConstructionOnSquareImpossible;

            TangibleAssetSquare checkedGameSquare = (TangibleAssetSquare)_gameBoard.GameSquares[VisualizedGameSquareID];
            
            if(checkedGameSquare.IsReachedMaximumLevel && checkedGameSquare.Owner == _playersMovesTurnService.MakingTurnPlayer)
                return ConstructionOpportunityStatus.MaximumBuildingLevelReachedOnSquare;

            if(_constructionService.CheckWhetherUserCanPurchaseNewBuildingLevel(checkedGameSquare, _playersMovesTurnService.MakingTurnPlayer))
                return ConstructionOpportunityStatus.ConstructionByOwnerOnSquarePossible;
            else
                return ConstructionOpportunityStatus.ConstructionByOwnerOnSquareImpossible;
        }

        private bool IsConstructionOnGameSquareProhibited() => _gameBoard.GameSquares[VisualizedGameSquareID] is not TangibleAssetSquare;

        private void VisuliazingTangibleAssetLevelChangedHandler(uint newAssetLevel) => View.UpdatePurchaseOpportunityVisualize();
    }
}