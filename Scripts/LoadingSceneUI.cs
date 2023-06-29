using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneUI : MonoBehaviour
{
    [SerializeField] private Image progressUI;
    string nextSceneName = "Terrain1";
    void Start()
    {

        StartCoroutine(LoadNextSceneAsync());
        progressUI.fillAmount = 0f;
    }

    IEnumerator LoadNextSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);

        while (!operation.isDone)
        {
            // Update your progress bar or loading indicator here
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressUI.fillAmount = progress;
            //Debug.Log("Loading progress: " + (progress * 100) + "%");

            yield return null;
        }
        // yield return null;
    }

}
