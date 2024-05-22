using System.Collections.Generic;
using Scripts.Game.Model.Player;
using Scripts.Game.Services.ChanceCardService.ChanceCards;
using UnityEngine;

namespace Scripts.Game.Services.ChanceCardService
{
    public sealed class ChanceCardService : MonoBehaviour
    {
        public ChanceCardService(EventCard[] chanceCards)
        {
            _chanceCards = chanceCards;
        }


        private EventCard[] _chanceCards;

        private List<(PlayerInfo, EventCard)> _chanceCardHistory = new List<(PlayerInfo, EventCard)>();


        public EventCard TakeChanceCard(PlayerInfo playerInfo)
        {
            EventCard chanceCard = _chanceCards[Random.Range(0, _chanceCards.Length)];
            _chanceCardHistory.Add((playerInfo, chanceCard));
            return chanceCard;
        }
    }
}