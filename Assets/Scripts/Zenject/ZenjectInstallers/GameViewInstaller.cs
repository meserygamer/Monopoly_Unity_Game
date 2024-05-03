using Scripts.Game.View;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class GameViewInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayersStatisticsShower>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BuyingDialog>().FromComponentInHierarchy().AsSingle();
        }
    }
}