using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyScript : MonoBehaviour
{
    public GameObject shopUI;
    //Arrays
    public int[] amt;
    public int[] cost;
    public int[] iconNum;
    public int[] inventoryItems;
    public Text[] itemAmtText;
    public Text currency;
    private Text compare;
    public bool tavern = false;
    private int max = 0;
    private bool canClick = true;
    // Start is called before the first frame update
    void Start()
    {
        max = itemAmtText.Length;
        currency.text = InventoryItems.gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CloseShop()
    {
        shopUI.SetActive(false);
    }
    public void BuyButton()
    {
        if (canClick == true)
        {


            for (int i = 0; i < max; i++)
            {
                if (itemAmtText[i] == compare)
                {
                    max = i;
                    if (amt[i] > 0)
                    {
                        if (tavern == true)
                        {
                            UpdateTavernAmt();
                        }
                        else
                        {
                            UpdateWizardAmt();
                        }
                        if (InventoryItems.gold >= cost[i])
                        {
                            if (inventoryItems[i] == 0)
                            {
                                InventoryItems.newIcon = iconNum[i];
                                InventoryItems.iconUpdate = true;
                            }
                            InventoryItems.gold -= cost[i];
                            if (tavern == true)
                            {
                                SetTavernAmt(i);
                            }
                            else
                            {
                                SetWizardAmt(i);
                            }
                        }
                    }
                }
            }
        }
    }
    void UpdateTavernAmt()
    {
        inventoryItems[0] = InventoryItems.bread;
        inventoryItems[1] = InventoryItems.cheese;
        inventoryItems[2] = InventoryItems.meat;
    }
    void UpdateWizardAmt()
    {
        inventoryItems[0] = InventoryItems.redPotion;
        inventoryItems[1] = InventoryItems.purplePotion;
        inventoryItems[2] = InventoryItems.bluePotion;
        inventoryItems[3] = InventoryItems.greenPotion;
        inventoryItems[4] = InventoryItems.dragonEgg;
        inventoryItems[5] = InventoryItems.root;
        inventoryItems[6] = InventoryItems.leafDew;
    }
    public void UpdateGold()
    {
        currency.text = InventoryItems.gold.ToString();
    }
    void SetTavernAmt(int item)
    {
        if (item == 0)
        {
            InventoryItems.bread++;
        }
        if (item == 1)
        {
            InventoryItems.cheese++;
        }
        if (item == 2)
        {
            InventoryItems.meat++;
        }
        amt[item]--;
        itemAmtText[item].text = amt[item].ToString();
        currency.text = InventoryItems.gold.ToString();
        max = itemAmtText.Length;
    }
    void SetWizardAmt(int item)
    {
        if (item == 0)
        {
            InventoryItems.redPotion++;
        }
        if (item == 1)
        {
            InventoryItems.purplePotion++;
        }
        if (item == 2)
        {
            InventoryItems.bluePotion++;
        }
        if (item == 3)
        {
            InventoryItems.greenPotion++;
        }
        if (item == 4)
        {
            InventoryItems.dragonEgg++;
        }
        if (item == 5)
        {
            InventoryItems.root++;
        }
        if (item == 6)
        {
            InventoryItems.leafDew++;
        }
        amt[item]--;
        itemAmtText[item].text = amt[item].ToString();
        currency.text = InventoryItems.gold.ToString();
        max = itemAmtText.Length;
    }
    public void redPotion()
    {
        compare = itemAmtText[0];
        Check2(0);
    }
    public void purplePotion()
    {
        compare = itemAmtText[1];
        Check2(1);
    }
    public void bluePotion()
    {
        compare = itemAmtText[2];
        Check2(2);
    }
    public void greenPotion()
    {
        compare = itemAmtText[3];
        Check2(3);
    }
    public void dragonEgg()
    {
        compare = itemAmtText[4];
        Check2(4);
    }
    public void root()
    {
        compare = itemAmtText[5];
        Check2(5);
    }
    public void leafDew()
    {
        compare = itemAmtText[6];
        Check2(6);
    }
    void Check(int b)
    {
        if (amt[b] > 0)
        {
            canClick = true;
        }
        else
        {
            canClick = false;
        }
    }
    void Check2(int c)
    {
        if (amt[c] > 0)
        {
            canClick = true;
        }
        else
        {
            canClick = false;
        }
    }
}
