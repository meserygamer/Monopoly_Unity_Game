namespace Scripts.Game.Services.ChanceCardService.ChanceCards
{
    public abstract class EventCard
    {
        public string ChanceCardText { get; protected set; }


        public abstract void RealizeCard();
    }
}