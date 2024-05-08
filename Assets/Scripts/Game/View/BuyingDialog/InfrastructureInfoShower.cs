using Scripts.Game.Model.GameField.GameSquare;


namespace Scripts.Game.View.BuyingDialog
{
    public class InfrastructureInfoShower : AssetInfoShower
    {
        public override void HideInfo() => gameObject.SetActive(false);
        public override void ShowInfo() => gameObject.SetActive(true);

        public override void SetUpInfo(OwnableSquare ownableSquare) {}
    }
}