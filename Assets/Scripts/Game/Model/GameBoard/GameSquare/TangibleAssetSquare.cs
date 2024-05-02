using Scripts.Game.Model.Player;

#nullable enable

namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Квадрат игрового поля с активом
    /// </summary>
    public class TangibleAssetSquare : GameSquareBase
    {
        public PlayerInfo? AssetOwner { get; private set; } = null;
        public uint AssetLevel { get; private set; } = 0;            // 1 - один домик, 2 - два домика, 3 - три домика, 4 - четыре домика, 5 - отель


        public void IncreaseAssetLevel()
        {
            if(AssetLevel == 5)
                return;
            AssetLevel++;
        }
        public void DecreaseAssetLevel()
        {
            if(AssetLevel == 0)
                return;
            AssetLevel--;
        }

        public void ChangeOwner(PlayerInfo newOwner)
        {
            if(newOwner == null)
                return;
            AssetOwner = newOwner;
        }
    }
}