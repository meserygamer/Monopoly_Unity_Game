using Scripts.Game.Model.Player;
using Scripts.Game.View;

namespace Scripts.Game.Presenter
{
    public class PlayersStatisticsShowerPresenter
    {
        public PlayersStatisticsShowerPresenter(PlayerRepository playerRepository, PlayersStatisticsShower view)
        {
            _playerRepository = playerRepository;
            _view = view;
            _playerRepository.PlayersInfoRegenerated += PlayersInfoRegeneratedHandler;
            _playerRepository.PlayersNameChanged += PlayersNameChangedHandler;
            _playerRepository.PlayersMoneyBalanceChanged += PlayersMoneyBalanceChangedHandler;
        }


        private PlayerRepository _playerRepository;

        private PlayersStatisticsShower _view;


        private void PlayersInfoRegeneratedHandler()
        {
            _view.GenerateStatisticsScreens(_playerRepository.PlayersInfo.Count);
            for(int i = 0; i < _playerRepository.PlayersInfo.Count; i++)
            {
                _view.SetPlayerNameIntoStatistics(i, _playerRepository.PlayersInfo[i].Name);
                _view.SetPlayerMoneyBalanceIntoStatistics(i, _playerRepository.PlayersInfo[i].BankAccount.MoneyAmount);
            }
        }

        private void PlayersNameChangedHandler(int playerID, string playerName)
        {
            _view.SetPlayerNameIntoStatistics(playerID, playerName);
        }

        private void PlayersMoneyBalanceChangedHandler(int playerID, int playerMoneyBalance)
        {
            _view.SetPlayerMoneyBalanceIntoStatistics(playerID, playerMoneyBalance);
        }
    }
}