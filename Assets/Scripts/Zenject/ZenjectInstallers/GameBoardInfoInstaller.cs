using Scripts.Game.GameField;
using Scripts.Game.Model.GameField;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class GameBoardInfoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameBoardInfo>().FromFactory<GameBoardInfoFactory>().AsSingle();
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