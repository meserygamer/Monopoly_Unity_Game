using System;
using System.Collections.Generic;
using Scripts.Game.Model.GameMaster;
using Scripts.Game.Services.ChanceCardService;
using Scripts.Game.Services.ChanceCardService.ChanceCards;
using Scripts.Game.View.ChanceAndCommunityChest;

namespace Scripts.Game.Presenter.ChanceAndCommunityChest
{
    public sealed class ChanceAndCommunityChestDialogPresenter
    {
        public ChanceAndCommunityChestDialogPresenter(ChanceAndCommunityChestMaster chanceAndCommunityChestMaster)
        {
            _chanceAndCommunityChestMaster = chanceAndCommunityChestMaster;

            _chanceAndCommunityChestMaster.EventCardWasGenerated += ChanceAndCommunityChestMasterEventCardWasGeneratedHandler;
        }


        private readonly ChanceAndCommunityChestMaster _chanceAndCommunityChestMaster;

        private ChanceAndCommunityChestDialog _view;

        private Dictionary<Type, Action<string>> _showingMethods;


        public ChanceAndCommunityChestDialog View 
        { 
            get => _view;
            set
            {
                _view = value;

                _showingMethods = new Dictionary<Type, Action<string>>()
                {
                    {typeof(ChanceCardService), _view.ShowChanceCard},
                    {typeof(CommunityChestCardService), _view.ShowCommunityChestCard}
                };
            }
        }


        private void ChanceAndCommunityChestMasterEventCardWasGeneratedHandler((Type, EventCard) FormeredCard)
        {
            if(View is null)
                return;

            _showingMethods[FormeredCard.Item1].Invoke(FormeredCard.Item2.EventCardText);
        }
    }
}
