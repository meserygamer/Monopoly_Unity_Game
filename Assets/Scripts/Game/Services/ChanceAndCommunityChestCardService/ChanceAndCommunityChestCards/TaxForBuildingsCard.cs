using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;

namespace Scripts.Game.Services.ChanceCardService.ChanceCards
{
    public sealed class TaxForBuildingsCard : EventCard
    {
        public TaxForBuildingsCard(   string cardText,
                                            uint moneyAmountPerHouse,
                                            uint moneyAmountPerHotel,
                                            BankingService bankingService,
                                            PlayersMovesTurnService playersMovesTurnService   )
        {
            _bankingService = bankingService;
            _playersMovesTurnService = playersMovesTurnService;

            base.ChanceCardText = cardText;
            _moneyAmountPerHouse = moneyAmountPerHouse;
            _moneyAmountPerHotel = moneyAmountPerHotel;
        }


        private BankingService _bankingService;
        private PlayersMovesTurnService _playersMovesTurnService;

        private uint _moneyAmountPerHouse;
        private uint _moneyAmountPerHotel;


        public override void RealizeCard() => 
            _bankingService.TakePlayerMoney(_playersMovesTurnService.MakingTurnPlayer, CalculateTaxSum());

        private uint CalculateTaxSum()
        {
            uint taxSum = 0;
            PlayerInfo player = _playersMovesTurnService.MakingTurnPlayer;

            foreach(var ownableSquare in player.BankAccount.GameSquaresInPossession)
            {
                if(ownableSquare is TangibleAssetSquare tangibleAsset)
                {
                    uint TaxForHouses = tangibleAsset.NumberOfHouses * _moneyAmountPerHouse;
                    uint TaxForHotels = tangibleAsset.NumberOfHotels * _moneyAmountPerHotel;

                    taxSum += TaxForHouses + TaxForHotels;
                }
            }

            return taxSum;
        }
    }
}