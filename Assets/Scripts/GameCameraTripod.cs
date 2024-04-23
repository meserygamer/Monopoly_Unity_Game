using ModestTree;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class GameCameraTripod : MonoBehaviour
    {
        private PlayerInput _playerInput;


        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }


        private void OnEnable()
        {
            _playerInput.CameraControl.RotateLeft.performed += RotateLeftPerformedHandler;
            _playerInput.CameraControl.RotateRight.performed += RotateRightPerformedHandler;
        }
        private void OnDisable()
        {
            _playerInput.CameraControl.RotateLeft.performed -= RotateLeftPerformedHandler;
            _playerInput.CameraControl.RotateRight.performed -= RotateRightPerformedHandler;
        }


        private void RotateRightPerformedHandler(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            transform.Rotate(Vector3.up, -20);
        }
        private void RotateLeftPerformedHandler(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            transform.Rotate(Vector3.up, 20);
        }
    }
}