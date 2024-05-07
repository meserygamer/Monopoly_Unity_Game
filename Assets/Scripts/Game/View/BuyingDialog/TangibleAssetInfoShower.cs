using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.View.BuyingDialog.TangibleAssetColors;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Game.View.BuyingDialog
{
    public class TangibleAssetInfoShower : AssetInfoShower
    {
        [SerializeField] private TextMeshProUGUI _tangibleAssetNameField;
        [SerializeField] private TextMeshProUGUI _tangibleAssetCommonRentalField;
        [SerializeField] private TextMeshProUGUI[] _tangibleAssetRentasFields;
        [SerializeField] private TextMeshProUGUI[] _tangibleAssetBuildingCostFields;

        [SerializeField] private Image _coloredForeground;
        [SerializeField] private TangibleAssetColor[] _tangibleAssetColors;

        public override void HideInfo() => gameObject.SetActive(false);
        public override void ShowInfo() => gameObject.SetActive(true);

        public override void SetUpInfo(OwnableSquare ownableSquare)
        {
            if(ownableSquare is not TangibleAssetSquare tangibleAssetSquare)
                return;

            _coloredForeground.color = _tangibleAssetColors[tangibleAssetSquare.QuestionSubtheme.QuestionTheme.ThemeID - 1].color;

            _tangibleAssetNameField.text = tangibleAssetSquare.Label;

            _tangibleAssetCommonRentalField.text = "Рента c участка $" + tangibleAssetSquare.RentalCosts[0].ToString();

            for(int i = 0; i < 5; i++)
            {
                _tangibleAssetRentasFields[i].text = "$" + tangibleAssetSquare.RentalCosts[i+1].ToString();
            }

            for(int i = 0; i < 2; i++)
            {
                _tangibleAssetBuildingCostFields[i].text = "$" + tangibleAssetSquare.ConstructionCosts[i].ToString();
            }
        }
    }
}