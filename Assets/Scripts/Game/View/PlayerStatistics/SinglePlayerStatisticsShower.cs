using Scripts.Game.Presenter;
using TMPro;
using UnityEngine;
using Zenject;

namespace Scripts.Game.View
{
    public class SinglePlayerStatisticsShower : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _playerNameTextField;
        [SerializeField] TextMeshProUGUI _playerBalanceTextField;


        public void SetPlayerName(string playerName)
        {
            _playerNameTextField.text = playerName;
        }
        public void SetPlayerBalance(int playerBalance)
        {
            _playerBalanceTextField.text = playerBalance.ToString() + "$";
        }
    }
}
