using Scripts.Game.View;
using Scripts.Game.View.BuyingDialog;
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