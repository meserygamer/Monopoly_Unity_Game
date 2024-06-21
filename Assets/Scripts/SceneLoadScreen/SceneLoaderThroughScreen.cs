using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderThroughScreen : MonoBehaviour
{
    public static string LoadSceneName = "SampleScene";

    [SerializeField] private Slider _progressBar;


    private void Start()
    {
        _progressBar.maxValue = 0.9f;
        StartCoroutine(LoadSceneCoroutine());
    }

    private IEnumerator LoadSceneCoroutine()
    {
        AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(LoadSceneName);
        sceneLoadOperation.allowSceneActivation = false;

        while (sceneLoadOperation.progress < 0.8)
        {
            _progressBar.value = sceneLoadOperation.progress;
            yield return new WaitForSeconds(0.01f);
        }
        _progressBar.value = sceneLoadOperation.progress;
        sceneLoadOperation.allowSceneActivation = true;
    }
}
