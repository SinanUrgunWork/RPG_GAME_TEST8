using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreatePotion : MonoBehaviour
{
    public int[] values;
    [HideInInspector]
    public int expectedValue;
    [HideInInspector]
    public int value;
    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;
    [HideInInspector]
    public int itemID = 0;
    private int max;
    [HideInInspector]
    public int thisValue;
    private int maxTwo;
    // Start is called before the first frame update
    void Start()
    {
        expectedValue = values[0];
        max = emptySlots.Length;
        maxTwo = emptySlots.Length;
        Create();
    }
    public void Create()
    {
        if (expectedValue == value)
        {
            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[itemID];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = itemID + 20;
                    value = 0;
                    thisValue = 0;
                }
            }
            max = emptySlots.Length;
        }
    }
    public void Removed(int index)
    {
        for (int i = 0; i < maxTwo; i++)
        {
            if (emptySlots[i] == icons[index])
            {
                maxTwo = i;
                emptySlots[i].sprite = emptyIcon;
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxTwo = emptySlots.Length;
    }
    public void UpdateValue()
    {
        value += thisValue;
        expectedValue = values[itemID];
    }
}
