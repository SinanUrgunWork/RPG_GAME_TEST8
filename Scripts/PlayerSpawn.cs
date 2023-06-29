using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] Characters;
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Characters[SaveScript.pchar], SpawnPoint.position, SpawnPoint.rotation);
    }

    // Update is called once per frame
    /*  void Update()
      {

      }*/
}
