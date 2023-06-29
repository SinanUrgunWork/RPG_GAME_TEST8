using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    public GameObject[] characters;
    private int P = 0;
    public Text playerName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Next()
    {
        if (P < characters.Length - 1)
        {
            characters[P].SetActive(false);
            P++;
            characters[P].SetActive(true);
        }
    }
    public void Back()
    {
        if (P > 0)
        {
            characters[P].SetActive(false);
            P--;
            characters[P].SetActive(true);
        }
    }
    public void Accept()
    {
        SaveScript.pchar = P;
        SaveScript.player = playerName.text;
        SceneManager.LoadScene(1);
    }
}
