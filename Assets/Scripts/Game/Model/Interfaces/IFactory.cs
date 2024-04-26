namespace Scripts.Game
{
    public interface IFactory <T>
    {
        T Create();
    }
}