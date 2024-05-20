using System;
using Scripts.Game.Model.Questions;

#nullable enable

namespace Scripts.Game.Model.GameField.GameSquare
{
    /// <summary>
    /// Квадрат игрового поля с активом
    /// </summary>
    public sealed class TangibleAssetSquare : OwnableSquare
    {
        public TangibleAssetSquare(QuestionSubtheme questionSubtheme, uint cost, uint[] rentalCosts, uint[] constructionCosts) : base(null, cost)
        {
            QuestionSubtheme = questionSubtheme;
            RentalCosts = rentalCosts;
            ConstructionCosts = constructionCosts;
        }


        public uint MAX_GAME_SQUARE_LEVEL = 5;
        public uint MIN_GAME_SQUARE_LEVEL = 0;


        private uint _assetLevel = 0;                                                               // 1 - один домик, 2 - два домика, 3 - три домика, 4 - четыре домика, 5 - отель


        public event Action<uint> AssetLevelChanged;


        public QuestionSubtheme QuestionSubtheme { get; }

        public uint AssetLevel 
        {
            get => _assetLevel;
            private set
            {
                _assetLevel = value;
                AssetLevelChanged?.Invoke(value);
            }
        }                                         

        public bool IsReachedMaximumLevel => AssetLevel == MAX_GAME_SQUARE_LEVEL;

        public override string Label => QuestionSubtheme.QuestionTheme.Title + ".\n" + QuestionSubtheme.Title;

        public uint[] RentalCosts { get; }                                                         // Стоимости аренды на каждом из уровней
        public uint[] ConstructionCosts { get; }                                                   // Стоимости строительства сооружений на клетке


        public bool IncreaseAssetLevel()
        {
            if(IsReachedMaximumLevel)
                return false;
            AssetLevel++;
            return true;
        }
        public bool DecreaseAssetLevel()
        {
            if(AssetLevel == MIN_GAME_SQUARE_LEVEL)
                return false;
            AssetLevel--;
            return true;
        }
    }
}