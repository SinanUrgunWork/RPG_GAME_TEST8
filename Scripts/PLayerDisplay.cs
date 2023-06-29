using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerDisplay : MonoBehaviour
{
    public GameObject[] playersDisplay;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playersDisplay.Length; i++)
        {
            playersDisplay[i].SetActive(false);
        }
        playersDisplay[SaveScript.pchar].SetActive(true);
    }
}
