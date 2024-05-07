using Scripts.Game.Model.GameField.GameSquare;
using TMPro;
using UnityEngine;

namespace Scripts.Game.View.BuyingDialog
{
    public class TemporaryAssetInfoShower : AssetInfoShower
    {
        [SerializeField] private TextMeshProUGUI _buyingDialogTextField;

        public override void HideInfo() => gameObject.SetActive(false);
        public override void ShowInfo() => gameObject.SetActive(true);

        public override void SetUpInfo(OwnableSquare ownableSquare)
        {
            _buyingDialogTextField.text = $"Вы желаете приобрести {ownableSquare.Label}\n(Приобретение будет стоить вам {ownableSquare.Cost}$)";
        }
    }
}