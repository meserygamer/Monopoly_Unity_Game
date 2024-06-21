using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Scripts.MainMenu.View
{
    public class MainMenu : MonoBehaviour
    {
        Button _buttonPlay;
        Button _buttonRules;
        Button _buttonExit;
        Button _buttonPlayDemo;

        
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            _buttonPlay = root.Q<Button>("PlayGameButton");
            _buttonRules = root.Q<Button>("RulesButton");
            _buttonExit = root.Q<Button>("ExitButton");
            _buttonPlayDemo = root.Q<Button>("PlayDemoButton");

            _buttonPlay.clicked += PlayGame;
            _buttonPlayDemo.clicked += PlayDemo;
            _buttonRules.clicked += ShowRules;
            _buttonExit.clicked += ExitGame;
        }


        private void PlayGame() 
        {
            Debug.Log("Пользователь запустил игру");
            SceneLoaderThroughScreen.LoadSceneName = "SampleScene";
            SceneManager.LoadScene("LoadGameScreen", LoadSceneMode.Single);
        }

        private void PlayDemo()
        {
            Debug.Log("Пользователь деморежим игру");
            SceneLoaderThroughScreen.LoadSceneName = "DemoVersion";
            SceneManager.LoadScene("LoadGameScreen", LoadSceneMode.Single);
        }

        private void ShowRules()
        {
            Debug.Log("Пользователь зашел в правила игры");
            SceneManager.LoadScene("RulesPage", LoadSceneMode.Additive);
        }

        private void ExitGame() => Application.Quit();
    }
}
