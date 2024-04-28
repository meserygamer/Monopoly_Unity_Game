using Scripts.Game.FinalStateMachine;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class LevelStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelStateMachine>().FromNew().AsSingle();
        }
    }
}