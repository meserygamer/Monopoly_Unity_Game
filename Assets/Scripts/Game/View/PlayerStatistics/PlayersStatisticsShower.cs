using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game.View
{
    public class PlayersStatisticsShower : MonoBehaviour
    {
        [SerializeField] private GameObject _statisticsScreenPrefab;
        [SerializeField] private Sprite[] _playerSprites;

        private List<SinglePlayerStatisticsShower> _singlePlayerStatisticsShowers = new List<SinglePlayerStatisticsShower>();


        public void GenerateStatisticsScreens(int PlayersCount)
        {
            for(int i = 0; i < PlayersCount; i++)
            {
                GameObject statisticsScreen = Instantiate(_statisticsScreenPrefab, transform);
                SinglePlayerStatisticsShower playerStatisticsShower = statisticsScreen.GetComponent<SinglePlayerStatisticsShower>();
                _singlePlayerStatisticsShowers.Add(playerStatisticsShower);

                if(_playerSprites.Length > i)
                    playerStatisticsShower.SetPlayerImage(_playerSprites[i]);
            }
        }

        public void SetPlayerNameIntoStatistics(int playerID, string name)
        {
            _singlePlayerStatisticsShowers[playerID].SetPlayerName(name);
        }
        public void SetPlayerMoneyBalanceIntoStatistics(int playerID, int playerMoneyBalance)
        {
            _singlePlayerStatisticsShowers[playerID].SetPlayerBalance(playerMoneyBalance);
        }

        public void SetPlayerSelection(int playerID)
        {
            ClearAllPlayerSelection();
            _singlePlayerStatisticsShowers[playerID].SetPlayerNameSelection();
        }

        private void ClearAllPlayerSelection()
        {
            foreach(var player in _singlePlayerStatisticsShowers)
                player.ClearPlayerNameSelection();
        }
    }
}
