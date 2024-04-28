using Scripts.Game.Model.GameField;
using Scripts.Game.Services;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class DiceRollServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DiceRollService>().FromNew().AsSingle();
        }
    }
}