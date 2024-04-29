using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Game.View
{
    public class PlayersStatisticsShower : MonoBehaviour
    {
        [SerializeField] private GameObject _statisticsScreenPrefab;

        private List<SinglePlayerStatisticsShower> _singlePlayerStatisticsShowers = new List<SinglePlayerStatisticsShower>();


        public void GenerateStatisticsScreens(int PlayersCount)
        {
            for(int i = 0; i < PlayersCount; i++)
            {
                GameObject statisticsScreen = Instantiate(_statisticsScreenPrefab, transform);
                _singlePlayerStatisticsShowers.Add(statisticsScreen.GetComponent<SinglePlayerStatisticsShower>());
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
    }
}
