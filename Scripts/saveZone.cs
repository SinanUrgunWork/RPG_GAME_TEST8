using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveZone : MonoBehaviour
{

    public GameObject saveScreen;
    public GameObject saveText;
    private bool savePause = false;
    // Start is called before the first frame update
    void Start()
    {
        saveScreen.SetActive(false);
        saveText.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && savePause == false)
        {
            saveScreen.SetActive(true);
            Time.timeScale = 0;
            savePause = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && savePause == true)
        {
            savePause = false;
        }
    }
    public void ChoodYes()
    {
        SaveScript.saving = true;
        saveText.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(Continue());
    }
    public void ChoodNo()
    {
        Time.timeScale = 1;
        saveScreen.SetActive(false);
    }

    IEnumerator Continue()
    {
        yield return new WaitForSeconds(1);
        saveScreen.SetActive(false);
        saveText.SetActive(false);
    }
}
