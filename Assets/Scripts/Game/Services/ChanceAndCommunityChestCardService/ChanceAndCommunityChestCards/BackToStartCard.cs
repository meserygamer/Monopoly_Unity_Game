namespace Scripts.Game.Services.ChanceCardService.ChanceCards
{
    public sealed class BackToStartCard : EventCard
    {
        public BackToStartCard(   PlayerMovementService playerMovementService,
                                        PlayersMovesTurnService playersMovesTurnService )
        {
            _playerMovementService = playerMovementService;
            _playersMovesTurnService = playersMovesTurnService;

            base.ChanceCardText = "Вернитесь на клетку \"Старт\"";
        }


        private PlayerMovementService _playerMovementService;

        private PlayersMovesTurnService _playersMovesTurnService;


        public override void RealizeCard() => 
            _playerMovementService.MovePlayerToDestinationPoint(_playersMovesTurnService.MakingTurnPlayer, 40);
    }
}