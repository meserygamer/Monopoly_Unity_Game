using Zenject;

namespace Scripts.Zenject.ZenjectInstallers
{
    public class PlayerInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerInput>().FromFactory<PlayerInputFactory>().AsSingle();
        }
    }

    public class PlayerInputFactory : IFactory<PlayerInput>
    {
        public PlayerInput Create()
        {
            PlayerInput playerInputFactory = new PlayerInput();
            playerInputFactory.Enable();
            return playerInputFactory;
        }
    }
}
