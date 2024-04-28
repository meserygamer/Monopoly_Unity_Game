using Scripts.Game.Model.Player;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class PlayerRepositoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerRepository>().FromNew().AsSingle();
        }
    }
}