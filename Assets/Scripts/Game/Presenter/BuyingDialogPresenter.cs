using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.GameMaster;
using Scripts.Game.View;
using Scripts.Game.View.BuyingDialog;

namespace Scripts.Game.Presenter
{
    public class BuyingDialogPresenter
    {
        public BuyingDialogPresenter(BuyingDialog view, RealEstateBuyingMaster realEstateBuyingMaster)
        {
            _view = view;
            _realEstateBuyingMaster = realEstateBuyingMaster;

            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare += MakingTurnPlayerCanBuySquareHandler;
            _view.PlayerPurchaseConfirmed += PlayerPurchaseConfirmedHandler;
            _view.PlayerPurchaseCanceled += PlayerPurchaseCanceledHandler;
        }


        ~BuyingDialogPresenter()
        {
            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare -= MakingTurnPlayerCanBuySquareHandler;
            _view.PlayerPurchaseConfirmed += PlayerPurchaseConfirmedHandler;
            _view.PlayerPurchaseCanceled += PlayerPurchaseCanceledHandler;
        }

        
        private BuyingDialog _view;
        private RealEstateBuyingMaster _realEstateBuyingMaster;


        private void MakingTurnPlayerCanBuySquareHandler(OwnableSquare gameSquare) => _view.SetDialogText(gameSquare);


        private void PlayerPurchaseConfirmedHandler() => _realEstateBuyingMaster.BuyGameSquareByMakingTurnPlayer();

        private void PlayerPurchaseCanceledHandler(){}
    }
}