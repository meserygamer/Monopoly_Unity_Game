namespace Scripts.Game.Services.ChanceCardService.ChanceCards
{
    public sealed class GetMoneyFromBankCard : EventCard
    {
        public GetMoneyFromBankCard(  string cardText,
                                            uint moneyAmount,
                                            BankingService bankingService,
                                            PlayersMovesTurnService playersMovesTurnService   )
        {
            _bankingService = bankingService;
            _playersMovesTurnService = playersMovesTurnService;

            base.ChanceCardText = cardText;
            _moneyAmount = moneyAmount;
        }


        private BankingService _bankingService;
        private PlayersMovesTurnService _playersMovesTurnService;

        private uint _moneyAmount;


        public override void RealizeCard() => 
            _bankingService.GivePlayerMoney(_playersMovesTurnService.MakingTurnPlayer, _moneyAmount);
    }
}