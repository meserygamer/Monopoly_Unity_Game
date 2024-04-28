using Scripts.Game.Services;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class PlayerMovementServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerMovementService>().FromNew().AsSingle();
        }
    }
}