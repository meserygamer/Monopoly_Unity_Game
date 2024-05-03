using System;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.GameMaster;
using Scripts.Game.View;
using UnityEngine;

#nullable enable

namespace Scripts.Game.StateMachine
{
    public class BuyingGameSquareState : LevelState
    {
        public BuyingGameSquareState(BuyingDialog buyingDialog)
        {
            _buyingDialog = buyingDialog;
        }


        private BuyingDialog _buyingDialog;


        private void BuyingDialogEndHandler() => base.StateMachine?.EnterIn<GoingGameState>();


        public override void EnterInState()
        {
            _buyingDialog.PlayerPurchaseCanceled += BuyingDialogEndHandler;
            _buyingDialog.PlayerPurchaseConfirmed += BuyingDialogEndHandler;

            _buyingDialog.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public override void ExitFromState()
        {
            _buyingDialog.PlayerPurchaseCanceled -= BuyingDialogEndHandler;
            _buyingDialog.PlayerPurchaseConfirmed -= BuyingDialogEndHandler;

            _buyingDialog.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}