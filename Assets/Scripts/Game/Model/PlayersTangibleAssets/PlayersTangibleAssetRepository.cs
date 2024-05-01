using System.Collections.Generic;
using System.Linq;
using Scripts.Game.Model.GameField;
using Scripts.Game.Model.GameField.GameSquare;
using Scripts.Game.Model.Player;

#nullable enable

namespace Scripts.Game.Model.PlayersTangibleAssets
{
    public class PlayersTangibleAssetRepository
    {
        public PlayersTangibleAssetRepository(PlayerRepository playerRepository, GameBoardInfo gameBoardInfo)
        {
            _playerRepository = playerRepository;
            _gameBoardInfo = gameBoardInfo;
            foreach(GameSquareBase gameSquareBase in gameBoardInfo.GameSquares)
            {
                if(gameSquareBase is TangibleAssetSquare tangibleAssetSquare)
                    _tangibleAssetSquareOwners.Add(tangibleAssetSquare, null);
            }
        }


        private readonly PlayerRepository _playerRepository;
        private readonly GameBoardInfo _gameBoardInfo;

        private readonly Dictionary<TangibleAssetSquare, PlayerInfo?> _tangibleAssetSquareOwners = new Dictionary<TangibleAssetSquare, PlayerInfo?>();
    }
}