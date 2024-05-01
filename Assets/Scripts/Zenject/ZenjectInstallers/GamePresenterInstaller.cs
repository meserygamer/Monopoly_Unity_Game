using Scripts.Game.Presenter;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class GamePresenterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerPositionShowerPresenter>().FromNew().AsTransient();
            Container.Bind<PlayersMovesTurnPresenter>().FromNew().AsTransient();
            Container.Bind<PlayersStatisticsShowerPresenter>().FromNew().AsTransient().NonLazy();
        }
    }
}