using Scripts.Game.Model.Player;
using Scripts.Game.Model.Questions;

#nullable enable

namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Квадрат игрового поля с активом
    /// </summary>
    public class TangibleAssetSquare : OwnableSquare
    {
        public TangibleAssetSquare(QuestionSubtheme questionSubtheme, uint cost) : base(null, cost)
        {
            _questionSubtheme = questionSubtheme;
        }


        private readonly QuestionSubtheme _questionSubtheme;


        public uint AssetLevel { get; private set; } = 0;            // 1 - один домик, 2 - два домика, 3 - три домика, 4 - четыре домика, 5 - отель

        public override string Label => "Тема - " + _questionSubtheme.QuestionTheme.Title + " Подтема - " + _questionSubtheme.Title;


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

        public override void ChangeOwner(PlayerInfo newOwner)
        {
            if(newOwner == null)
                return;
            Owner = newOwner;
        }
    }
}