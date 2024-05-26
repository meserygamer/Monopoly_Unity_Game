using Scripts.Game.Model.Player;
using Scripts.Game.Services.ChanceCardService.ChanceCards;

public interface IEventCardProvider
{
    EventCard TakeEventCard(PlayerInfo playerInfo);
}