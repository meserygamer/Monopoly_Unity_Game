using System;
using System.Collections.Generic;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;
using Scripts.Game.Services.ChanceCardService;
using Scripts.Game.Services.ChanceCardService.ChanceCards;

namespace Scripts.Game.Model.GameMaster
{
    public class ChanceAndCommunityChestMaster
    {
        public ChanceAndCommunityChestMaster(   PlayerMovementService playerMovementService,
                                                GameBoardInfo gameBoardInfo,
                                                ChanceCardService chanceCardService,
                                                CommunityChestCardService communityChestCardService)
        {
            _playerMovementService = playerMovementService;
            _gameBoardInfo = gameBoardInfo;
            _eventCardProviderMap = new Dictionary<Type, IEventCardProvider>()
            {
                { typeof(ChanceGameSquare), chanceCardService},
                { typeof(CommunityChestGameSquare), communityChestCardService} 
            };

            _playerMovementService.PlayerPositionChanged += PlayerPositionChangedHandler;
        }


        private PlayerMovementService _playerMovementService;
        private GameBoardInfo _gameBoardInfo;

        private Dictionary<Type, IEventCardProvider> _eventCardProviderMap; 


        public event Action<(Type, EventCard)> EventCardWasGenerated;


        private void PlayerPositionChangedHandler(PlayerInfo player, int playerID, uint? passedGameSquaresCount, uint newPlayerPosition)
        {
            GameSquareInfoBase gameSquareWherePlayerStands = _gameBoardInfo.GameSquares[(int)newPlayerPosition];

            if(!_eventCardProviderMap.TryGetValue(gameSquareWherePlayerStands.GetType(), out IEventCardProvider eventCardProvider))
                return;

            EventCard eventCard = eventCardProvider.TakeEventCard(player);
            eventCard.RealizeCard();
            EventCardWasGenerated?.Invoke((eventCardProvider.GetType(), eventCard));
        }
    }
}
