using Scripts.Game.View;
using Scripts.Game.View.BuyingDialog;
using Scripts.Game.View.ChanceAndCommunityChest;
using Scripts.Game.View.PlayerOwnershipVisualizer;
using Scripts.Game.View.QuestionDialog;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class GameViewInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayersStatisticsShower>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BuyingDialog>().FromComponentInHierarchy().AsSingle();
            Container.Bind<GameSquareOwnershipVisualizerCoordinator>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ConstructionModeButton>().FromComponentInHierarchy().AsSingle();
            Container.Bind<QuestionDialog>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ChanceAndCommunityChestDialog>().FromComponentInHierarchy().AsSingle();
        }
    }
}