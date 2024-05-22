using Scripts.Game.Model.Player;
using Scripts.Game.Services;
using Scripts.Game.Services.ChanceCardService;
using Scripts.Game.Services.ChanceCardService.ChanceCards;
using Scripts.Game.Services.CostOfRentServices;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class GameServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DiceRollService>().FromNew().AsSingle();
            Container.Bind<PlayerMovementService>().FromNew().AsSingle();
            Container.Bind<PlayersMovesTurnService>().FromNew().AsSingle();
            Container.Bind<BankingService>().FromNew().AsSingle();
            Container.Bind<RealEstatePurchaseService>().FromNew().AsSingle();
            Container.Bind<ConstructionService>().FromNew().AsSingle();
            Container.Bind<QuestionService>().FromNew().AsSingle();

            Container.Bind<InfrastructureRentCostCalculatorService>().FromNew().AsSingle();
            Container.Bind<RailroadRentCostCalculatorService>().FromNew().AsSingle();
            Container.Bind<TangibleAssetRentCostCalculatorService>().FromNew().AsSingle();

            Container.Bind<ChanceCardService>().FromFactory<ChanceCardServiceFactory>().AsSingle();
            Container.Bind<CommunityChestCardService>().FromFactory<CommunityChestCardServiceFactory>().AsSingle();
        }
    }

    public sealed class ChanceCardServiceFactory : IFactory<ChanceCardService>
    {
        public ChanceCardServiceFactory(BankingService bankingService,
                                        PlayersMovesTurnService playersMovesTurnService,
                                        PlayerMovementService playerMovementService,
                                        PlayerRepository playerRepository )
        {
            _bankingService = bankingService;
            _playersMovesTurnService = playersMovesTurnService;
            _playerMovementService = playerMovementService;
            _playerRepository = playerRepository;
        }


        private BankingService _bankingService;
        private PlayersMovesTurnService _playersMovesTurnService;
        private PlayerMovementService _playerMovementService;
        private PlayerRepository _playerRepository;


        public ChanceCardService Create()
        {
            return new ChanceCardService(new EventCard[] 
            {
                new GetMoneyFromBankCard("Вы заняли второе место на олимпиаде по математике, получите 40", 40, _bankingService, _playersMovesTurnService),
                new BackToStartCard(_playerMovementService, _playersMovesTurnService),
                new TaxForBuildingsCard("Сбор на обновление темы – заплатите 40 за каждый дом и 115 за каждый отель", 40, 115, _bankingService, _playersMovesTurnService),
                new TakeMoneyToBankCard("Штраф за опоздание – заплатите 25", 25, _bankingService, _playersMovesTurnService),
                new GetMoneyFromBankCard("Возврат долга – получите 150", 150, _bankingService, _playersMovesTurnService),
                new GetMoneyFromAllPlayersCard("С днем рождения – получите 15 с каждого игрока", 15, _bankingService, _playersMovesTurnService, _playerRepository),
                new GetMoneyFromBankCard("Поощрение по итогам семестра – получите 50", 50, _bankingService, _playersMovesTurnService),
                new TakeMoneyToBankCard("Опоздание на экзамен – заплатите 45", 45, _bankingService, _playersMovesTurnService),
                new TakeMoneyToBankCard("Запись на дополнительные занятия – заплатите 150", 150, _bankingService, _playersMovesTurnService),
                new GetMoneyFromBankCard("Вы выиграли олимпиаду – получите 100", 100, _bankingService, _playersMovesTurnService),
            });
        }
    }

    public sealed class CommunityChestCardServiceFactory : IFactory<CommunityChestCardService>
    {
        public CommunityChestCardServiceFactory(BankingService bankingService,
                                                PlayersMovesTurnService playersMovesTurnService,
                                                PlayerRepository playerRepository )
        {
            _bankingService = bankingService;
            _playersMovesTurnService = playersMovesTurnService;
            _playerRepository = playerRepository;
        }


        private BankingService _bankingService;
        private PlayersMovesTurnService _playersMovesTurnService;
        private PlayerRepository _playerRepository;    


        public CommunityChestCardService Create()
        {
            return new CommunityChestCardService(new EventCard[] 
            {
                new GetMoneyFromBankCard("Дополнительное начисление стипендии – получите 200", 200, _bankingService, _playersMovesTurnService),
                new GetMoneyFromBankCard("Получение разовой повышенной стипендии – получите 100", 200, _bankingService, _playersMovesTurnService),
                new TakeMoneyToBankCard("Возмещение налога – получите 25", 25, _bankingService, _playersMovesTurnService),
                new TakeMoneyToBankCard("Оплата питания – заплатите 50", 50, _bankingService, _playersMovesTurnService),
                new GetMoneyFromBankCard("Вы заняли второе место на олимпиаде по математике, получите 40", 40, _bankingService, _playersMovesTurnService),
                new GetMoneyFromBankCard("Выгодное вложение стипендии – получите 50", 50, _bankingService, _playersMovesTurnService),
                new TakeMoneyToBankCard("Оплата проездного – заплатите 100", 100, _bankingService, _playersMovesTurnService),
                new GetMoneyFromBankCard("Возврат средств за поездку на студенческий слет – получите 100", 100, _bankingService, _playersMovesTurnService),
                new GetMoneyFromAllPlayersCard("С днем рождения – получите 15 с каждого игрока", 15, _bankingService, _playersMovesTurnService, _playerRepository),
            });
        }
    }
}