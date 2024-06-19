using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Game.View
{
    public class SinglePlayerStatisticsShower : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _playerNameTextField;
        [SerializeField] TextMeshProUGUI _playerBalanceTextField;
        [SerializeField] Image _playerImage;


        public void SetPlayerName(string playerName)
        {
            _playerNameTextField.text = playerName;
        }
        public void SetPlayerBalance(int playerBalance)
        {
            _playerBalanceTextField.text = playerBalance.ToString() + "$";
        }
        public void SetPlayerImage(Sprite sprite) => _playerImage.sprite = sprite;
        public void SetPlayerNameSelection() => _playerNameTextField.color = Color.red;
        public void ClearPlayerNameSelection() => _playerNameTextField.color = Color.white;
    }
}
