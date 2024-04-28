using Scripts.Game.Presenter;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class PlayerPositionShowerPresenterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerPositionShowerPresenter>().FromNew().AsTransient();
        }
    }
}