using Scripts.Game.Services;
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

            Container.Bind<InfrastructureRentCostCalculatorService>().FromNew().AsSingle();
            Container.Bind<RailroadRentCostCalculatorService>().FromNew().AsSingle();
            Container.Bind<TangibleAssetRentCostCalculatorService>().FromNew().AsSingle();
        }
    }
}