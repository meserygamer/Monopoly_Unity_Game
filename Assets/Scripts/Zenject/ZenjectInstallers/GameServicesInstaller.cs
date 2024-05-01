using Scripts.Game.Services;
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
        }
    }
}