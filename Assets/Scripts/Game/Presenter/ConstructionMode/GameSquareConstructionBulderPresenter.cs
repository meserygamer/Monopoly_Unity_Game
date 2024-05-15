using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Services;
using Scripts.Game.View.ConstructionMode;
using UnityEngine;

namespace Scripts.Game.Presenter.ConstructionMode
{
    public sealed class GameSquareConstructionBulderPresenter
    {
        public GameSquareConstructionBulderPresenter(ConstructionService constructionService, GameBoardInfo gameBoardInfo, PlayersMovesTurnService playersMovesTurnService)
        {
            _constructionService = constructionService;
            _gameBoardInfo = gameBoardInfo;
            _playersMovesTurnService = playersMovesTurnService;
        }


        private readonly ConstructionService _constructionService;

        private readonly GameBoardInfo _gameBoardInfo;

        private readonly PlayersMovesTurnService _playersMovesTurnService;


        public GameSquareConstructionBulder View {get; set;}


        public void BuildBuildingOnGameSquare(uint gameSquareID)
        {
            TangibleAssetSquare upgradingGameSquare = _gameBoardInfo.GameSquares[(int)gameSquareID] as TangibleAssetSquare;
            if(_constructionService.CheckWhetherUserCanPurchaseNewBuildingLevel(upgradingGameSquare, _playersMovesTurnService.MakingTurnPlayer))
            {
                Debug.Log("Игрок может улучшить клетку");
                _constructionService.BuildBuildingNextLevel(upgradingGameSquare);
            }
            else
            {
                Debug.Log("Игрок не может улучшить клетку");
            }    
        }
    }
}