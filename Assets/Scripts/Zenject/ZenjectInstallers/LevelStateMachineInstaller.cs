using Scripts.Game.StateMachine;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class LevelStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelStateMachine>().FromNew().AsSingle();
            Container.Bind<GoingGameState>().FromNew().AsSingle();
            Container.Bind<StartLevelState>().FromNew().AsSingle();
            Container.Bind<BuyingGameSquareState>().FromNew().AsSingle();
            Container.Bind<LevelStates>().FromFactory<LevelStatesFactory>().AsSingle();
        }
    }

    public class LevelStatesFactory : IFactory<LevelStates>
    {
        public LevelStatesFactory(  StartLevelState startLevelState,
                                    GoingGameState goingGameState,
                                    BuyingGameSquareState buyingGameSquareState  )
        {
            _startLevelState = startLevelState;
            _goingGameState = goingGameState;
            _buyingGameSquareState = buyingGameSquareState;
        }


        private StartLevelState _startLevelState;
        private GoingGameState _goingGameState;
        private BuyingGameSquareState _buyingGameSquareState;


        public LevelStates Create()
        {
            return new LevelStates()
            { 
                StartLevelState = _startLevelState,
                GoingGameState = _goingGameState,
                BuyingGameSquareState = _buyingGameSquareState
            };
        }
    }
}