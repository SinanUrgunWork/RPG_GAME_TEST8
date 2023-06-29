using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator anim;
    public int goldAmt = 50;
    public bool crate = false;

    // Start is called before the first frame update
    void Start()
    {
        if (crate == false)
        {
            anim = GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (InventoryItems.key == true)
                {
                    anim.SetTrigger("open");
                    InventoryItems.gold += goldAmt;
                    goldAmt = 0;
                    Debug.Log("Gold amt = " + InventoryItems.gold + " gold");
                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (InventoryItems.key == true)
                {
                    anim.SetTrigger("close");
                }
            }
        }

    }
    public void DestroyChest()
    {
        Destroy(gameObject);
    }
    public void Particles()
    {
        if (crate == true)
        {
            InventoryItems.gold += goldAmt;
            goldAmt = 0;
        }
    }
}
