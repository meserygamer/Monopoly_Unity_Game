using Scripts.Game.GameField.GameSquare;

namespace Scripts.Game.GameField
{
    public class BasicGameFieldFactory : IFactory<GameFieldInfo>
    {
        public GameFieldInfo Create()
        {
            GameFieldInfo gameFieldInfo = new GameFieldInfo();
            gameFieldInfo.GameSquares.Add(new StartGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new TaxGameSquare());
            gameFieldInfo.GameSquares.Add(new RailRoadGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ChanceGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new JailVisitGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new InfrastructureGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new RailRoadGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ParkingGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ChanceGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new RailRoadGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new InfrastructureGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new GoToJailGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new CommunityChestGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new RailRoadGameSquare());
            gameFieldInfo.GameSquares.Add(new ChanceGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            gameFieldInfo.GameSquares.Add(new TaxGameSquare());
            gameFieldInfo.GameSquares.Add(new ActiveGameSquare());
            return gameFieldInfo;
        }
    }
}