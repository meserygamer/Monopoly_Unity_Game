#nullable enable

using Scripts.Game.View.QuestionDialog;
using UnityEngine;

namespace Scripts.Game.StateMachine
{
    public class PlayerAnswearingQuestionState : LevelState
    {
        public PlayerAnswearingQuestionState(QuestionDialog questionDialog)
        {
            _questionDialog = questionDialog;
        }


        private QuestionDialog _questionDialog;


        private void QuestionDialogEndHandler() => base.StateMachine?.EnterIn<PlayerMakingTurnState>();


        public override void EnterInState()
        {
            _questionDialog.QuestionWindowClosed += QuestionDialogEndHandler;

            _questionDialog.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        public override void ExitFromState()
        {
            _questionDialog.QuestionWindowClosed -= QuestionDialogEndHandler;

            _questionDialog.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}