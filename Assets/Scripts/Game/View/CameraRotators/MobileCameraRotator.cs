using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.Game.View.CameraRotators
{
    public class MobileCameraRotator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public enum RotationDirection
        {
            Left,
            Right,
        }


        [SerializeField] private GameCameraTripod _gameCameraTripod;
        [SerializeField] private RotationDirection _rotationDirection;

        private bool isPointerDown = false;


        public void OnPointerDown(PointerEventData eventData) => isPointerDown = true;
        public void OnPointerUp(PointerEventData eventData) => isPointerDown = false;


        private void LateUpdate()
        {
            if(isPointerDown) 
                _gameCameraTripod.RotateTripod((_rotationDirection == RotationDirection.Left)? -1 : 1);
        }
    }
}