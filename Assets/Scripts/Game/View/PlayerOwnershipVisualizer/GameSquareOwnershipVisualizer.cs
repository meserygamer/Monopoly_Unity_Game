using UnityEngine;

namespace Scripts.Game.View.PlayerOwnershipVisualizer
{
    [RequireComponent(typeof(GameSquare))]
    public class GameSquareOwnershipVisualizer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _ownershipRenderer;
        [SerializeField] private Sprite[] _playersSprites;

        private GameSquare _gameSquare;


        public GameSquare GameSquare => _gameSquare;


        private void Awake()
        {
            _gameSquare = GetComponent<GameSquare>();
        }


        public void VisualizePlayerOwnership(uint? playerID)
        {
            if(playerID is null)
                HideOwnershipMark();
            ChangeOwnershipMark((uint)playerID);
        }

        private void HideOwnershipMark() => _ownershipRenderer.sprite = null;

        private void ChangeOwnershipMark(uint playerID) => _ownershipRenderer.sprite = _playersSprites[playerID];
    }
}