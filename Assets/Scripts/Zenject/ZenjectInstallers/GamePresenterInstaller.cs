using Scripts.Game.Presenter;
using Scripts.Game.Presenter.ConstructionMode;
using Scripts.Game.Presenter.QuestionDialog;
using Scripts.Game.Presenter.TangibleAssetLevelVisualizer;
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
            Container.Bind<BuyingDialogPresenter>().FromNew().AsTransient().NonLazy();
            Container.Bind<GameSquareOwnershipVisualizerCoordinatorPresenter>().FromNew().AsTransient();
            Container.Bind<PurchaseOpportunityVisualizerPresenter>().FromNew().AsTransient();
            Container.Bind<GameSquareConstructionBulderPresenter>().FromNew().AsTransient();
            Container.Bind<TangibleAssetLevelShowerPresenter>().FromNew().AsTransient();
            Container.Bind<QuestionDialogPresenter>().FromNew().AsTransient();
        }
    }
}