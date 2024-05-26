using System;
using System.Collections.Generic;
using Scripts.Game.Model.Player;
using Scripts.Game.Services.ChanceCardService.ChanceCards;

namespace Scripts.Game.Services.ChanceCardService
{
     public sealed class CommunityChestCardService : IEventCardProvider
    {
        public CommunityChestCardService(EventCard[] communityChestCards)
        {
            _communityChestCards = communityChestCards;
        }


        private EventCard[] _communityChestCards;

        private List<(PlayerInfo, EventCard)> _communityChestCardHistory = new List<(PlayerInfo, EventCard)>();


        public EventCard TakeEventCard(PlayerInfo playerInfo) => TakeCommunityChestCard(playerInfo);


        public EventCard TakeCommunityChestCard(PlayerInfo playerInfo)
        {
            EventCard chanceCard = _communityChestCards[new Random().Next(0, _communityChestCards.Length)];
            _communityChestCardHistory.Add((playerInfo, chanceCard));
            return chanceCard;
        }
    }
}