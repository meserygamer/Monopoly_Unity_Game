#nullable enable

using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.View.TangibleAssetLevelVisualizer;

namespace Scripts.Game.Presenter.TangibleAssetLevelVisualizer
{
    public sealed class TangibleAssetLevelShowerPresenter
    {
        public TangibleAssetLevelShowerPresenter(GameBoardInfo gameBoardInfo)
        {
            _gameBoardInfo = gameBoardInfo;
        }


        private readonly GameBoardInfo _gameBoardInfo;

        private TangibleAssetSquare? _trackedTangibleAsset = null;

        private TangibleAssetLevelShower _view = null!;


        public TangibleAssetLevelShower View 
        {
            get => _view;
            set
            {
                _view = value;
                _trackedTangibleAsset = _gameBoardInfo.GameSquares[(int)_view.TrackedTangibleAssetID] as TangibleAssetSquare;
                _trackedTangibleAsset!.AssetLevelChanged += TrackedTangibleAssetLevelChangedHandler;
            }
        }


        public void UpdateTangibleAssetLevel() => TrackedTangibleAssetLevelChangedHandler(_trackedTangibleAsset!.AssetLevel);

        private void TrackedTangibleAssetLevelChangedHandler(uint newAssetLevel) => View.UpdateShowingTangibleAssetLevel(newAssetLevel);
    } 
}