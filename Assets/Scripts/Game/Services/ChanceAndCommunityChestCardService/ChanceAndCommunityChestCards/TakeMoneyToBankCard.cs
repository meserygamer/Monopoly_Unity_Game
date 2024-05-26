namespace Scripts.Game.Services.ChanceCardService.ChanceCards
{
    public sealed class TakeMoneyToBankCard : EventCard
    {
        public TakeMoneyToBankCard(   string cardText,
                                            uint moneyAmount,
                                            BankingService bankingService,
                                            PlayersMovesTurnService playersMovesTurnService   )
        {
            _bankingService = bankingService;
            _playersMovesTurnService = playersMovesTurnService;

            base.EventCardText = cardText;
            _moneyAmount = moneyAmount;
        }


        private BankingService _bankingService;
        private PlayersMovesTurnService _playersMovesTurnService;

        private uint _moneyAmount;


        public override void RealizeCard() => 
            _bankingService.TakePlayerMoney(_playersMovesTurnService.MakingTurnPlayer, _moneyAmount);
    }
}