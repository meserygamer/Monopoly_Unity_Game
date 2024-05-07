using Scripts.Game.Model.GameField.GameSquare;
using UnityEngine;

namespace Scripts.Game.View.BuyingDialog
{
    public abstract class AssetInfoShower : MonoBehaviour
    {
        public abstract void SetUpInfo(OwnableSquare ownableSquare);

        public abstract void HideInfo();
        public abstract void ShowInfo();
    }
}