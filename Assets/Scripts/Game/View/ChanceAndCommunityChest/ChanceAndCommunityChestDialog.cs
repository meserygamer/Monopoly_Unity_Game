using System;
using Scripts.Game.Presenter.ChanceAndCommunityChest;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace Scripts.Game.View.ChanceAndCommunityChest
{
    public sealed class ChanceAndCommunityChestDialog : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dialogLabel;
        [SerializeField] private TextMeshProUGUI _dialogText;
        [SerializeField] private RawImage _chanceImage;
        [SerializeField] private RawImage _communityChest;

        private ChanceAndCommunityChestDialogPresenter _presenter;


        [Inject]
        private void Constructor(ChanceAndCommunityChestDialogPresenter presenter)
        {
            _presenter = presenter;
            _presenter.View = this;
        }


        public event Action ChanceAndCommunityChestDialogClosed;


        public void EndDialog() => ChanceAndCommunityChestDialogClosed?.Invoke();

        public void ShowChanceCard(string cardText)
        {
            _dialogLabel.text = "шанс";
            _dialogText.text = cardText;
            _chanceImage.gameObject.SetActive(true);
            _communityChest.gameObject.SetActive(false);
        }
        public void ShowCommunityChestCard(string cardText)
        {
            _dialogLabel.text = "общественная казна";
            _dialogText.text = cardText;
            _chanceImage.gameObject.SetActive(false);
            _communityChest.gameObject.SetActive(true);
        }
    }
}
