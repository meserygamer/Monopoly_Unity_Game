using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;

namespace Scripts.Game.GameField
{
    public class BasicGameFieldFactory
    {
        public GameBoardInfo Create()
        {
            GameBoardInfo gameBoardInfo = new GameBoardInfo();
            for(int i = 0; i < 40; i++)
            {
                gameBoardInfo.GameSquares.Add(new TangibleAssetSquare());
            }
            return gameBoardInfo;
        }
    }
}