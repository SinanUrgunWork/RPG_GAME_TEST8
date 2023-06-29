using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public GameObject myCamera;
    private bool canSpawn = true;
    public bool reSpawner = true;

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canSpawn == true)
            {
                canSpawn = false;
                for (int i = 0; i < enemies.Length; i++)
                {
                    Instantiate(enemies[i], spawnPoints[i].position, spawnPoints[i].rotation);
                    SaveScript.enemiesOnScreen++;
                }
            }
        }
    }
}
