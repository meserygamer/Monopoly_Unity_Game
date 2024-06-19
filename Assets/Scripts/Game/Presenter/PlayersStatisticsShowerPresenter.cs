using System;
using Scripts.Game.Model.Player;
using Scripts.Game.Services;
using Scripts.Game.View;

namespace Scripts.Game.Presenter
{
    public class PlayersStatisticsShowerPresenter
    {
        public PlayersStatisticsShowerPresenter(PlayerRepository playerRepository, 
                                                PlayersStatisticsShower view,
                                                PlayersMovesTurnService playersMovesTurnService)
        {
            _playerRepository = playerRepository;
            _playersMovesTurnService = playersMovesTurnService;
            _view = view;

            _playerRepository.PlayersInfoRegenerated += PlayersInfoRegeneratedHandler;
            _playerRepository.PlayersNameChanged += PlayersNameChangedHandler;
            _playerRepository.PlayersMoneyBalanceChanged += PlayersMoneyBalanceChangedHandler;
            _playersMovesTurnService.MakingTurnPlayerPositionWasChanged += MakingTurnPlayerPositionWasChangedHandler;
        }

        
        private PlayerRepository _playerRepository;
        private PlayersMovesTurnService _playersMovesTurnService; 

        private PlayersStatisticsShower _view;


        private void PlayersInfoRegeneratedHandler()
        {
            _view.GenerateStatisticsScreens(_playerRepository.PlayersInfo.Count);
            for(int i = 0; i < _playerRepository.PlayersInfo.Count; i++)
            {
                _view.SetPlayerNameIntoStatistics(i, _playerRepository.PlayersInfo[i].Name);
                _view.SetPlayerMoneyBalanceIntoStatistics(i, _playerRepository.PlayersInfo[i].BankAccount.MoneyAmount);
            }
            if(_playersMovesTurnService.MakingTurnPlayer is not null)
                MakingTurnPlayerPositionWasChangedHandler(_playersMovesTurnService.MakingTurnPlayer);
        }

        private void PlayersNameChangedHandler(int playerID, string playerName) => 
            _view.SetPlayerNameIntoStatistics(playerID, playerName);

        private void PlayersMoneyBalanceChangedHandler(int playerID, int playerMoneyBalance) => 
            _view.SetPlayerMoneyBalanceIntoStatistics(playerID, playerMoneyBalance);

        private void MakingTurnPlayerPositionWasChangedHandler(PlayerInfo info) => 
            _view.SetPlayerSelection(_playerRepository.GetPlayerID(info));

    }
}