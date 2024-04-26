using UnityEngine;
using Zenject;

namespace Scripts.Game
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


        private void Update()
        {
            float rotationVector = _playerInput.CameraControl.CameraRotate.ReadValue<float>();
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime * -rotationVector);
        }
    }
}