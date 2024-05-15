using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.GameMaster;

namespace Scripts.Game.StateMachine
{
    public class PlayerMakingTurnState : LevelState
    {
        public PlayerMakingTurnState(RealEstateBuyingMaster realEstateBuyingMaster)
        {
            _realEstateBuyingMaster = realEstateBuyingMaster;
        }


        private RealEstateBuyingMaster _realEstateBuyingMaster;


        private void BuyingDialogStartHandler(OwnableSquare square) => base.StateMachine?.EnterIn<BuyingGameSquareState>();


        public override void EnterInState()
        {
            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare += BuyingDialogStartHandler;
        }

        public override void ExitFromState()
        {
            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare -= BuyingDialogStartHandler;
        }
    }
}