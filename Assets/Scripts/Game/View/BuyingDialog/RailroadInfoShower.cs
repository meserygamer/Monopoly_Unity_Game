using Scripts.Game.Model.GameField.GameSquare;
using TMPro;
using UnityEngine;


namespace Scripts.Game.View.BuyingDialog
{
    public class RailroadInfoShower : AssetInfoShower
    {
        [SerializeField] private TextMeshProUGUI _railroadLabelField;


        public override void HideInfo() => gameObject.SetActive(false);
        public override void ShowInfo() => gameObject.SetActive(true);

        public override void SetUpInfo(OwnableSquare ownableSquare)
        {
            if(ownableSquare is not RailRoadGameSquare tangibleAssetSquare)
                return;

            _railroadLabelField.text = tangibleAssetSquare.Label;
        }
    }
}
