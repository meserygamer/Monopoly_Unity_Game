using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;
using static UnityEngine.InputSystem.InputAction;

namespace Scripts.Game.View.PauseMenu
{
    public class PauseMenuShower : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _rulesButton;
        [SerializeField] private Button _exitToMainMenuButton;

        [SerializeField] private GameObject _pauseCanvas;

        private PlayerInput _inputActions;

        private bool _isRulesPageLoading;


        [Inject]
        private void Constructor(PlayerInput inputActions)
        {
            _inputActions = inputActions;
        }


        private void OnEnable()
        {
            _continueButton?.onClick.AddListener(SwitchGameMenu);
            _rulesButton?.onClick.AddListener(OpenRulesScene);
            _exitToMainMenuButton?.onClick.AddListener(ExitToMainMenu);

            _inputActions.CameraControl.PauseMenuSwitch.performed += SwitchGameMenu;
        }
        private void OnDisable()
        {
            _continueButton?.onClick.RemoveListener(SwitchGameMenu);
            _rulesButton?.onClick.RemoveListener(OpenRulesScene);
            _exitToMainMenuButton?.onClick.RemoveListener(ExitToMainMenu);

            _inputActions.CameraControl.PauseMenuSwitch.performed -= SwitchGameMenu;
        }


        public void SwitchGameMenu(CallbackContext callBackContext)
        {
            if(_pauseCanvas is null)
                return;

            _pauseCanvas.SetActive(!_pauseCanvas.activeInHierarchy);
        }
        public void SwitchGameMenu() => SwitchGameMenu(new CallbackContext());
        private void OpenRulesScene()
        {
            if(_isRulesPageLoading)
                return;

            _isRulesPageLoading = true;
            AsyncOperation _loadRulesOperation = SceneManager.LoadSceneAsync("RulesPage", LoadSceneMode.Additive);
            _loadRulesOperation.completed += (a) => _isRulesPageLoading = false;
        }
        private void ExitToMainMenu()
        {
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        }
    }
}
