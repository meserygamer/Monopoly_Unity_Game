using Scripts.Game.StateMachine;
using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class LevelStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelStateMachine>().FromNew().AsSingle();
            Container.Bind<PlayerMakingTurnState>().FromNew().AsSingle();
            Container.Bind<StartLevelState>().FromNew().AsSingle();
            Container.Bind<BuyingGameSquareState>().FromNew().AsSingle();
            Container.Bind<PlayerAnswearingQuestionState>().FromNew().AsSingle();
            Container.Bind<LevelStates>().FromFactory<LevelStatesFactory>().AsSingle();
        }
    }

    public class LevelStatesFactory : IFactory<LevelStates>
    {
        public LevelStatesFactory(  StartLevelState startLevelState,
                                    PlayerMakingTurnState goingGameState,
                                    BuyingGameSquareState buyingGameSquareState,
                                    PlayerAnswearingQuestionState playerAnswearingQuestionState )
        {
            _startLevelState = startLevelState;
            _goingGameState = goingGameState;
            _buyingGameSquareState = buyingGameSquareState;
            _playerAnswearingState = playerAnswearingQuestionState;
        }


        private StartLevelState _startLevelState;
        private PlayerMakingTurnState _goingGameState;
        private BuyingGameSquareState _buyingGameSquareState;
        private PlayerAnswearingQuestionState _playerAnswearingState;


        public LevelStates Create()
        {
            return new LevelStates()
            { 
                StartLevelState = _startLevelState,
                PlayerMakingTurnState = _goingGameState,
                BuyingGameSquareState = _buyingGameSquareState,
                PlayerAnswearingQuestionState = _playerAnswearingState
            };
        }
    }
}