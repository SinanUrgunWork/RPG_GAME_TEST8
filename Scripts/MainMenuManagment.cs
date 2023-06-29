using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagment : MonoBehaviour
{
    [SerializeField] private GameObject newGameUI;
    [SerializeField] private GameObject quitGameUI;

    public void QuitGameUI()
    {
        Application.Quit();
    }
    public void NewGameUI()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
