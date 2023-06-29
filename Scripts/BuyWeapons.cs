using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWeapons : MonoBehaviour
{
    public int weaponNumber = 0;
    public int cost;
    public Text currencyText;
    public GameObject inventoryObj;

    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = InventoryItems.gold.ToString();

    }

    public void BuyWeaponButton()
    {
        if (InventoryItems.gold >= cost)
        {
            InventoryItems.gold -= cost;
            inventoryObj.GetComponent<InventoryItems>().weapons[weaponNumber] = true;
            currencyText.text = InventoryItems.gold.ToString();
        }
    }
}
