using System;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.GameMaster;
using Scripts.Game.View;
using UnityEngine;

#nullable enable

namespace Scripts.Game.FinalStateMachine
{
    public class BuyingGameSquareState : ILevelState
    {
        public BuyingGameSquareState(BuyingDialog buyingDialog, RealEstateBuyingMaster realEstateBuyingMaster)
        {
            _buyingDialog = buyingDialog;
            _realEstateBuyingMaster = realEstateBuyingMaster; 
            _buyingDialog.PlayerPurchaseCanceled += BuyingDialogEndHandler;
            _buyingDialog.PlayerPurchaseConfirmed += BuyingDialogEndHandler;
            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare += BuyingDialogStartHandler;
        }


        private BuyingDialog _buyingDialog;
        private RealEstateBuyingMaster _realEstateBuyingMaster;


        public LevelStateMachine? LevelStateMachine { get; set; } = null;


        private void BuyingDialogEndHandler() => LevelStateMachine?.EnterIn<GoingGameState>();

        private void BuyingDialogStartHandler(OwnableSquare square) => LevelStateMachine?.EnterIn<BuyingGameSquareState>();



        public void EnterInState()
        {
            _buyingDialog.gameObject.active = true;
            Time.timeScale = 0f;
        }

        public void ExitFromState()
        {
            _buyingDialog.gameObject.active = false;
            Time.timeScale = 1.0f;
        }
    }
}