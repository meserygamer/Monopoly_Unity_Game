using System;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.GameMaster;
using Scripts.Game.Services.ChanceCardService.ChanceCards;

namespace Scripts.Game.StateMachine
{
    public class PlayerMakingTurnState : LevelState
    {
        public PlayerMakingTurnState(   RealEstateBuyingMaster realEstateBuyingMaster,
                                        QuestionMaster questionMaster,
                                        ChanceAndCommunityChestMaster chanceAndCommunityChestMaster)
        {
            _realEstateBuyingMaster = realEstateBuyingMaster;
            _questionMaster = questionMaster;
            _chanceAndCommunityChestMaster = chanceAndCommunityChestMaster;
        }


        private RealEstateBuyingMaster _realEstateBuyingMaster;
        private QuestionMaster _questionMaster;
        private ChanceAndCommunityChestMaster _chanceAndCommunityChestMaster;


        private void QuestionMasterPlayerQuestionWasGenerated(uint questionIndex) => base.StateMachine?.EnterIn<PlayerAnswearingQuestionState>();
        private void BuyingDialogStartHandler(OwnableSquare square) => base.StateMachine?.EnterIn<BuyingGameSquareState>();
        private void ChanceAndCommunityChestMasterEventCardWasGeneratedHandler((Type, EventCard) card) => base.StateMachine?.EnterIn<ChanceAndCommunityChestCardState>();


        public override void EnterInState()
        {
            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare += BuyingDialogStartHandler;
            _questionMaster.PlayerQuestionWasGenerated += QuestionMasterPlayerQuestionWasGenerated;
            _chanceAndCommunityChestMaster.EventCardWasGenerated += ChanceAndCommunityChestMasterEventCardWasGeneratedHandler;
        }

        public override void ExitFromState()
        {
            _realEstateBuyingMaster.MakingTurnPlayerCanBuySquare -= BuyingDialogStartHandler;
            _questionMaster.PlayerQuestionWasGenerated -= QuestionMasterPlayerQuestionWasGenerated;
            _chanceAndCommunityChestMaster.EventCardWasGenerated -= ChanceAndCommunityChestMasterEventCardWasGeneratedHandler;
        }
    }
}