using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.GameMaster;

namespace Scripts.Game.StateMachine
{
    public class PlayerMakingTurnState : LevelState
    {
        public PlayerMakingTurnState(RealEstateBuyingMaster realEstateBuyingMaster, QuestionMaster questionMaster)
        {
            _realEstateBuyingMaster = realEstateBuyingMaster;
            _questionMaster = questionMaster;
        }


        private RealEstateBuyingMaster _realEstateBuyingMaster;

        private QuestionMaster _questionMaster;


        public override void EnterInState()
        {
            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare += BuyingDialogStartHandler;
            _questionMaster.PlayerQuestionWasGenerated += QuestionMasterPlayerQuestionWasGenerated;
        }

        public override void ExitFromState()
        {
            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare -= BuyingDialogStartHandler;
            _questionMaster.PlayerQuestionWasGenerated -= QuestionMasterPlayerQuestionWasGenerated;
        }

        private void QuestionMasterPlayerQuestionWasGenerated(uint questionIndex) => base.StateMachine?.EnterIn<PlayerAnswearingQuestionState>();

        private void BuyingDialogStartHandler(OwnableSquare square) => base.StateMachine?.EnterIn<BuyingGameSquareState>();
    }
}