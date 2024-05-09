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
        public TangibleAssetSquare(QuestionSubtheme questionSubtheme, uint cost, uint[] rentalCosts, uint[] constructionCosts) : base(null, cost)
        {
            QuestionSubtheme = questionSubtheme;
            RentalCosts = rentalCosts;
            ConstructionCosts = constructionCosts;
        }


        public QuestionSubtheme QuestionSubtheme { get; }

        public uint AssetLevel { get; private set; } = 0;                                          // 1 - один домик, 2 - два домика, 3 - три домика, 4 - четыре домика, 5 - отель

        public override string Label => "Тема - " + QuestionSubtheme.QuestionTheme.Title + " Подтема - " + QuestionSubtheme.Title;

        public uint[] RentalCosts { get; }                                                         // Стоимости аренды на каждом из уровней
        public uint[] ConstructionCosts { get; }                                                   // Стоимости строительства сооружений на клетке


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
    }
}