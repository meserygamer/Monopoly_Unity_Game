using Scripts.Game.Presenter;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class PlayersMovesTurnPresenterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayersMovesTurnPresenter>().FromNew().AsTransient();
        }
    }
}