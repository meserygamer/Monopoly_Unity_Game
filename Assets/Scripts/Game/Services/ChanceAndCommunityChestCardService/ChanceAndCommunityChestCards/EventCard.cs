namespace Scripts.Game.Services.ChanceCardService.ChanceCards
{
    public abstract class EventCard
    {
        public string EventCardText { get; protected set; }


        public abstract void RealizeCard();
    }
}