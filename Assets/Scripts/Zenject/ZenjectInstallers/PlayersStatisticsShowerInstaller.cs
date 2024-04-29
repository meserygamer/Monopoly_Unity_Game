using Scripts.Game.Presenter;
using Scripts.Game.View;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class PlayersStatisticsShowerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayersStatisticsShower>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayersStatisticsShowerPresenter>().FromNew().AsTransient().NonLazy();
        }
    }
}