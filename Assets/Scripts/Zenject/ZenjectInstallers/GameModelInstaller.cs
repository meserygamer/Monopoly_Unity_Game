using Scripts.Game.GameField;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameMaster;
using Scripts.Game.Model.Player;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class GameModelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameBoardInfo>().FromFactory<GameBoardInfoFactory>().AsSingle();
            Container.Bind<PlayerRepository>().FromNew().AsSingle();
            Container.Bind<AwardingRewardsMaster>().FromNew().AsSingle().NonLazy();
            Container.Bind<RealEstateBuyingMaster>().FromNew().AsSingle().NonLazy();
            Container.Bind<RentPaymentMaster>().FromNew().AsSingle().NonLazy();
            Container.Bind<QuestionMaster>().FromNew().AsSingle().NonLazy();
            Container.Bind<ChanceAndCommunityChestMaster>().FromNew().AsSingle().NonLazy();
        }
    }

    public class GameBoardInfoFactory : IFactory<GameBoardInfo>
    {
        public GameBoardInfo Create()
        {
            GameBoardInfo gameBoard = new BasicGameFieldFactory().Create();
            return gameBoard;
        }
    }
}