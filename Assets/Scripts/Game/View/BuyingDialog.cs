using System;
using TMPro;
using UnityEngine;

namespace Scripts.Game.View
{
    public class BuyingDialog : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buyingDialogTextField;


        public event Action PlayerPurchaseConfirmed;
        public event Action PlayerPurchaseCanceled;


        public void SetDialogText(string squareLabel, uint squareCost)
        {
            _buyingDialogTextField.text = $"Вы желаете приобрести {squareLabel}\n(Приобретение будет стоить вам {squareCost}$)";
        }

        public void ConfirmBuy()
        {
            PlayerPurchaseConfirmed?.Invoke();
        }

        public void CancelBuy()
        {
            PlayerPurchaseCanceled?.Invoke();
        }
    }
}
