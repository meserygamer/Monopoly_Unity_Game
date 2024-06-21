using System;
using System.Collections.Generic;
using Scripts.Game.Model.GameField.GameSquare;
using TMPro;
using UnityEngine;

namespace Scripts.Game.View.BuyingDialog
{
    public class BuyingDialog : MonoBehaviour
    {
        [SerializeField] private InfrastructureInfoShower _waterStationInfoShower;
        [SerializeField] private InfrastructureInfoShower _lightStationInfoShower;
        [SerializeField] private TangibleAssetInfoShower _tangibleAssetInfoShower;
        [SerializeField] private RailroadInfoShower _railroadInfoShower;

        [SerializeField] private TextMeshProUGUI _ownableSquarePriceField;

        private Dictionary<Type, AssetInfoShower> _assetsWithdrawalMethods;


        public event Action PlayerPurchaseConfirmed;
        public event Action PlayerPurchaseCanceled;


        public void SetDialogText(OwnableSquare ownableSquare)
        {
            if(_assetsWithdrawalMethods is null)
                InitAssetsWithdrawalMethods();

            if(!_assetsWithdrawalMethods.TryGetValue(ownableSquare.GetType(), out AssetInfoShower assetInfoShower))
                return;

            assetInfoShower.SetUpInfo(ownableSquare);
            _ownableSquarePriceField.text = "Стоимость: $" + ownableSquare.Cost;

            foreach(var infoShower in _assetsWithdrawalMethods.Values)
                infoShower.HideInfo();
            assetInfoShower.ShowInfo();
        }

        public void ConfirmBuy()
        {
            PlayerPurchaseConfirmed?.Invoke();
        }
        public void CancelBuy()
        {
            PlayerPurchaseCanceled?.Invoke();
        }

        private void InitAssetsWithdrawalMethods()
        {
            _assetsWithdrawalMethods = new Dictionary<Type, AssetInfoShower>
            {
                { typeof(TangibleAssetSquare), _tangibleAssetInfoShower },
                { typeof(WaterStationGameSquare), _waterStationInfoShower },
                { typeof(LightStationGameSquare), _lightStationInfoShower },
                { typeof(RailRoadGameSquare), _railroadInfoShower }
            };
        }
    }
}
