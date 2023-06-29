using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimColl : MonoBehaviour
{
    public GameObject shortSword;
    public GameObject longSword;
    public GameObject shortAxe;
    public GameObject longAxe;
    // Start is called before the first frame update
    void Start()
    {
        shortSword.GetComponent<BoxCollider>().enabled = false;
    }

    public void ColliderOn()
    {
        shortSword.GetComponent<BoxCollider>().enabled = true;
    }
    public void ColliderOff()
    {
        shortSword.GetComponent<BoxCollider>().enabled = false;
    }
}
