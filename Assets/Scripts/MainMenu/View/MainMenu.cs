using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Scripts.MainMenu.View
{
    public class MainMenu : MonoBehaviour
    {
        Button _buttonPlay;
        Button _buttonPreferences;
        Button _buttonExit;
        
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            _buttonPlay = root.Q<Button>("PlayGameButton");
            _buttonPreferences = root.Q<Button>("PreferencesButton");
            _buttonExit = root.Q<Button>("ExitButton");

            _buttonPlay.clicked += PlayGame;
            _buttonPreferences.clicked += ShowPreferences;
            _buttonExit.clicked += ExitGame;
        }


        private void PlayGame() 
        {
            Debug.Log("Пользователь запустил игру");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

        private void ShowPreferences()
        {
            Debug.Log("Зашел в настройки игры");
            SceneManager.LoadScene("RulesPage", LoadSceneMode.Additive);
        }

        private void ExitGame() => Application.Quit();
    }
}
