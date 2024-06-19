using UnityEngine;
using Zenject;

namespace Scripts
{
    public class GameCameraTripod : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 5;
        private PlayerInput _playerInput;


        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }


        public void RotateTripod(float rotationDirection) => 
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime * -rotationDirection);

        private void LateUpdate() =>
            RotateTripod(_playerInput.CameraControl.CameraRotate.ReadValue<float>());
    }
}