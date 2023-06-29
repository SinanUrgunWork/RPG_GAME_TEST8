using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject continueButton;
    public GameObject loadingScreen;
    public GameObject saveObject;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.persistentDataPath + "/save.dat" != null)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
        Cursor.visible = true;
    }

    public void ContinueGame()
    {
        loadingScreen.SetActive(true);
        saveObject.SetActive(true);
        SaveScript.continueData = true;
        StartCoroutine(WaitToLoad());
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
