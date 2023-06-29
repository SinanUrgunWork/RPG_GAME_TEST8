using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int number;
    public bool redMushroom = false;
    public bool blueFlower = false;
    public bool purpleMushroom = false;
    public bool coins = false;
    public GameObject inventoryObject;

    void Start()
    {
        if (coins == true)
        {
            Destroy(gameObject, 5);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (redMushroom == true)
            {
                if (InventoryItems.redMushroom == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.redMushroom++;
                Destroy(gameObject);
            }
            else if (blueFlower == true)
            {
                if (InventoryItems.blueFlower == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.blueFlower++;
                Destroy(gameObject);
            }
            else if (purpleMushroom == true)
            {
                if (InventoryItems.purpleMushroom == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.purpleMushroom++;
                Destroy(gameObject);
            }
            else if (coins == true)
            {
                InventoryItems.gold += Random.Range(5, 250);
                Destroy(gameObject);
            }
            //do it for every item you want and it's gonna make tham disappear after there amount become 0
            else
            {
                DisplayIcons();
                Destroy(gameObject);
            }

        }

    }
    void DisplayIcons()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
    }
}
