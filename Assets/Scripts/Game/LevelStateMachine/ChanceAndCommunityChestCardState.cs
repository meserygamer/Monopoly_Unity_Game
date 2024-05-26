#nullable enable

using Scripts.Game.View.ChanceAndCommunityChest;
using UnityEngine;

namespace Scripts.Game.StateMachine
{
    public class ChanceAndCommunityChestCardState : LevelState
    {
        public ChanceAndCommunityChestCardState(ChanceAndCommunityChestDialog chanceAndCommunityChestDialog)
        {
            _chanceAndCommunityChestDialog = chanceAndCommunityChestDialog;
        }


        private ChanceAndCommunityChestDialog _chanceAndCommunityChestDialog;


        private void QuestionDialogEndHandler() => base.StateMachine?.EnterIn<PlayerMakingTurnState>();


        public override void EnterInState()
        {
            _chanceAndCommunityChestDialog.ChanceAndCommunityChestDialogClosed += QuestionDialogEndHandler;

            _chanceAndCommunityChestDialog.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public override void ExitFromState()
        {
            _chanceAndCommunityChestDialog.ChanceAndCommunityChestDialogClosed -= QuestionDialogEndHandler;

            _chanceAndCommunityChestDialog.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}