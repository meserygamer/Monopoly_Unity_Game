using Scripts.Game.Model.Player;

namespace Scripts.Game.Services.ChanceCardService.ChanceCards
{
    public sealed class GetMoneyFromAllPlayersCard : EventCard
    {
        public GetMoneyFromAllPlayersCard(string cardText,
                                                uint moneyAmountFromSinglePlayer,
                                                BankingService bankingService,
                                                PlayersMovesTurnService playersMovesTurnService,
                                                PlayerRepository playerRepository)
        {
            _bankingService = bankingService;
            _playersMovesTurnService = playersMovesTurnService;
            _playerRepository = playerRepository;

            base.EventCardText = cardText;
            _moneyAmountFromSinglePlayer = moneyAmountFromSinglePlayer;
        }


        private BankingService _bankingService;
        private PlayersMovesTurnService _playersMovesTurnService;
        private PlayerRepository _playerRepository;

        private uint _moneyAmountFromSinglePlayer;


        public override void RealizeCard()
        {
            foreach(var player in _playerRepository.PlayersInfo)
            {
                if(player == _playersMovesTurnService.MakingTurnPlayer)
                    continue;
                
                _bankingService.TransferMoneyBetweenPlayers(player, _playersMovesTurnService.MakingTurnPlayer, _moneyAmountFromSinglePlayer);
            }
        }
    }
}