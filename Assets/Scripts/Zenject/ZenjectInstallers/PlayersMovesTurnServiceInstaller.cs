using Scripts.Game.Services;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class PlayersMovesTurnServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayersMovesTurnService>().FromNew().AsSingle();
        }
    }
}