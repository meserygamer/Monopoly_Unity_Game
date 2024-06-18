using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Scripts.RulesPage.View
{
    public class BackToMainMenuButton : MonoBehaviour
    {
        private Button _backMenuButton;


        private void OnEnable()
        {
            _backMenuButton = GetComponent<Button>();
            _backMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void OnDisable()
        {
            _backMenuButton.onClick.RemoveListener(GoToMainMenu);
        }


        public void GoToMainMenu()
        {
            SceneManager.UnloadSceneAsync("RulesPage");
        }
    }
}